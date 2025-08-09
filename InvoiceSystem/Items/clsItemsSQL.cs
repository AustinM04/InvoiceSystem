using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Items
{
	internal class clsItemsSQL
	{
		/// <summary>
		/// This SQL gets all item details
		/// </summary>
		/// <returns>SQL Select Statement as string</returns>
		public static string GetAllItemDetails()
		{
            try
            {
                return "SELECT ItemCode, ItemDesc, Cost from ItemDesc";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

		/// <summary>
		/// This SQL gets all the invoices that contain a specific item code.
		/// </summary>
		/// <param name="itemCode">The item code to retrieve all invoices for.</param>
		/// <returns>All invoices for the given item code.</returns>
		public static string GetItemWithCode(string itemCode)
		{
            try
            {
                return $"SELECT distinct(InvoiceNum) from LineItems where ItemCode = '{itemCode}'";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

		/// <summary>
		/// SQL to update existing item
		/// </summary>
		public static string UpdateItem(string itemDesc, string itemCost, string itemCode)
		{
            try
            {
                return $"Update ItemDesc Set ItemDesc = '{itemDesc}', Cost = {itemCost} where ItemCode = '{itemCode}'";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

		/// <summary>
		/// This SQL inserts a new item into the ItemDesc table
		/// </summary>
		/// <param name="itemCode">Item code for the new item</param>
		/// <param name="itemDesc">Description for the new item</param>
		/// <param name="itemPrice">Price for the new item</param>
		/// <returns></returns>
		public static string InsertItem(string itemCode, string itemDesc, string itemPrice)
		{
            try
            {
                return $"Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('{itemCode}', '{itemDesc}', {itemPrice});";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

		/// <summary>
		/// This SQL deletes an item from the ItemDesc table based on the item code
		/// </summary>
		/// <param name="itemCode"></param>
		/// <returns></returns>
		public static string DeleteItem(string itemCode)
		{
            try
            {
                return $"Delete from ItemDesc Where ItemCode = '{itemCode}'";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
	}
}
