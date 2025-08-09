using InvoiceSystem;
using System;
using System.Windows;
using InvoiceSystem.Common;
using InvoiceSystem.Search;
using InvoiceSystem.Items;
using System.Reflection;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Data;

namespace InvoiceSystem.Items
{
	public class clsItemsLogic
	{
        /// <summary>
        /// Declaring a new instance of the data access class to interact with the database
        /// </summary>
        clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// Method to get all items from the database 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public List<clsItem> GetItems()
		{
			try
			{
				string sSQL = clsItemsSQL.GetAllItemDetails();
				List<clsItem> items = new();
				int iRetVal = 0;
				DataSet ds = new();
				ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);
				for (int i = 0; i < iRetVal; i++)
				{
					items.Add(new clsItem(
						ds.Tables[0].Rows[i]["ItemCode"].ToString(),
						ds.Tables[0].Rows[i]["ItemDesc"].ToString(),
						ds.Tables[0].Rows[i]["Cost"].ToString()
					));
				}
				return items;
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + 
					MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Method to get all invoices that contain a specific item code
		/// </summary>
		/// <param name="itemCode">Item's code</param>
		/// <param name="description">Item's description</param>
		/// <param name="cost">Item's cost</param>
		/// <exception cref="Exception"></exception>
		public void AddItem(string itemCode, string description, string cost)
		{
			try
			{
				string sSQL = clsItemsSQL.InsertItem(itemCode, description, cost);
				int iRetVal = db.ExecuteNonQuery(sSQL);
				if (iRetVal == 0)
				{
					throw new Exception("No rows were inserted.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + 
					MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Method to update an existing item in the database
		/// </summary>
		/// <param name="itemDesc">Item's description</param>
		/// <param name="itemCost">Item's cost</param>
		/// <param name="itemCode">Item's code</param>
		/// <exception cref="Exception"></exception>
		public void UpdateItem(string itemDesc, string itemCost, string itemCode)
		{
			try
			{
				string sSQL = clsItemsSQL.UpdateItem(itemDesc, itemCost, itemCode);
				int iRetVal = db.ExecuteNonQuery(sSQL);
				if (iRetVal == 0)
				{
					throw new Exception("No rows were updated.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + 
					MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		/// <summary>
		/// This method deletes an item from the database based on the item code.
		/// </summary>
		/// <param name="item">Item to be deleted</param>
		/// <exception cref="Exception"></exception>
		public void DeleteItem(clsItem item)
		{
			try
			{
				string sSQL = clsItemsSQL.DeleteItem(item.sItemCode);
				int iRetVal = db.ExecuteNonQuery(sSQL);
				if (iRetVal == 0)
				{
					throw new Exception("No rows were deleted.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
					MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
	}
}