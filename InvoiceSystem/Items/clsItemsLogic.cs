using InvoiceSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Items
{
		internal class clsItemsLogic
		{
				/// <summary>
				/// Connection string to the database.
				/// </summary>
				private string sConnectionString;
				/// <summary>
				/// Constructor that sets the connection string to the database
				/// </summary>
				public clsItemsLogic()
				{
						try
						{
								sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\Invoice.accdb";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// This method takes an SQL statment that is passed in and executes it.  The resulting values
				/// are returned in a DataSet.  The number of rows returned from the query will be put into
				/// the reference parameter iRetVal.
				/// </summary>
				/// <param name="sSQL">The SQL statement to be executed.</param>
				/// <param name="iRetVal">Reference parameter that returns the number of selected rows.</param>
				/// <returns>Returns a DataSet that contains the data from the SQL statement.</returns>
				public DataSet ExecuteSQLStatement(string sSQL, ref int iRetVal)
				{
						try
						{
								//Create a new DataSet
								DataSet ds = new DataSet();

								using (OleDbConnection conn = new OleDbConnection(sConnectionString))
								{
										using (OleDbDataAdapter adapter = new OleDbDataAdapter())
										{

												//Open the connection to the database
												conn.Open();

												//Add the information for the SelectCommand using the SQL statement and the connection object
												adapter.SelectCommand = new OleDbCommand(sSQL, conn);
												adapter.SelectCommand.CommandTimeout = 0;

												//Fill up the DataSet with data
												adapter.Fill(ds);
										}
								}

								//Set the number of values returned
								iRetVal = ds.Tables[0].Rows.Count;

								//return the DataSet
								return ds;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// This method takes an SQL statment that is a non query and executes it.
				/// </summary>
				/// <param name="sSQL">The SQL statement to be executed.</param>
				/// <returns>Returns the number of rows affected by the SQL statement.</returns>
				public int ExecuteNonQuery(string sSQL)
				{
						try
						{
								//Number of rows affected
								int iNumRows;

								using (OleDbConnection conn = new OleDbConnection(sConnectionString))
								{
										//Open the connection to the database
										conn.Open();

										//Add the information for the SelectCommand using the SQL statement and the connection object
										OleDbCommand cmd = new OleDbCommand(sSQL, conn);
										cmd.CommandTimeout = 0;

										//Execute the non query SQL statement
										iNumRows = cmd.ExecuteNonQuery();
								}

								//return the number of rows affected
								return iNumRows;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Method to get all items from the database 
				/// </summary>
				/// <returns></returns>
				/// <exception cref="Exception"></exception>
				public List<clsItem> GetItems()
				{
						try
						{
								string sSQL = clsItemsSQL.GetAllItemDetails();
								List<clsItem> items = new();
								int iRetVal = 0;
								DataSet ds = new();
								ds = ExecuteSQLStatement(sSQL, ref iRetVal);
								for (int i = 0; i < iRetVal; i++)
								{
										items.Add(new clsItem() { 
												sItemCode = ds.Tables[0].Rows[i]["ItemCode"].ToString(),
												sDescription = ds.Tables[0].Rows[i]["ItemDesc"].ToString(),
												sCost = ds.Tables[0].Rows[i]["Cost"].ToString()
										});
								}
								return items;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								int iRetVal = ExecuteNonQuery(sSQL);
								if (iRetVal == 0)
								{
										throw new Exception("No rows were inserted.");
								}
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								int iRetVal = ExecuteNonQuery(sSQL);
								if (iRetVal == 0)
								{
										throw new Exception("No rows were updated.");
								}
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								int iRetVal = ExecuteNonQuery(sSQL);
								if (iRetVal == 0)
								{
										throw new Exception("No rows were deleted.");
								}
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}


		}
}
