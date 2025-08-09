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

namespace InvoiceSystem.Search
{
		public class clsSearchLogic
		{
				#region class variables
				/// <summary>
				/// Declaring a new instance of the data access class to interact with the database
				/// </summary>
				clsDataAccess db = new clsDataAccess();

				#endregion

				#region get distinct values methods
				/// <summary>
				/// This method will get the sql string to get all invoice numbers then it will use the
				/// data access class to get the dataset of the values
				/// </summary>
				/// <returns>A list of strings representing the distinct invoice numbers</returns>
				/// <exception cref="Exception"></exception>
				public List<string> GetDistinctInvoiceNumbers()
				{
						try
						{
								string sSQL = clsSearchSQL.GetAllInvoiceNums();
								List<string> nums = new();
								int iRetVal = 0;
								DataSet ds = new();
								ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);
								for (int i = 0; i < iRetVal; i++)
								{
										nums.Add(ds.Tables[0].Rows[i]["InvoiceNum"].ToString());
								}
								return nums;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// This method will get the sql string to get all invoice dates then it will use the
				///	data access class to get the dataset of the values
				/// </summary>
				/// <returns>A list of strings representing distinct invoice dates</returns>
				/// <exception cref="Exception"></exception>
				public List<string> GetDistinctDates()
				{
						try
						{
								string sSQL = clsSearchSQL.GetAllInvoiceDates();
								List<string> dates = new();
								int iRetVal = 0;
								DataSet ds = new();
								ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);
								for (int i = 0; i < iRetVal; i++)
								{
										dates.Add(ds.Tables[0].Rows[i]["InvoiceDate"].ToString());
								}
								return dates;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}
				/// <summary>
				/// Gets all of the distinct total costs from the invoices
				/// </summary>
				/// <returns></returns>
				/// <exception cref="Exception"></exception>
				public List<string> GetDistinctCosts()
				{
						try
						{
								string sSQL = clsSearchSQL.GetAllInvoiceTotals();
								List<string> costs = new();
								int iRetVal = 0;
								DataSet ds = new();
								ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);
								for (int i = 0; i < iRetVal; i++)
								{
										costs.Add(ds.Tables[0].Rows[i]["TotalCost"].ToString());
								}
								return costs;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}
				#endregion

				#region get invoice via parameters method
				/// <summary>
				/// Gets a list of invoices based on which parameters were provided
				/// </summary>
				/// <param name="invoiceNumber">Number of the invoice(s)</param>
				/// <param name="invoiceDate">Date of the invoice(s)</param>
				/// <param name="totalCost">Total cost of the invoice(s)</param>
				/// <returns>A List of Invoices matching input parameters</returns>
				/// <exception cref="Exception"></exception>
				public List<clsInvoice> GetInvoices(string? invoiceNumber, string? invoiceDate, string? totalCost)
				{
						// This method is going to get the sql string to get invoices by invoice number date and cost
						// and determine which sql statement to use based on the parameters passed in

						try
						{
								string sSQL = clsSearchSQL.GetAllInvoices();
								List<clsInvoice> invoices = new();

								if (string.IsNullOrEmpty(invoiceNumber) && string.IsNullOrEmpty(invoiceDate) && !string.IsNullOrEmpty(totalCost))
								{
										sSQL = clsSearchSQL.GetInvoicesWithCost(totalCost);
								}
								else if (!string.IsNullOrEmpty(invoiceNumber) && string.IsNullOrEmpty(invoiceDate) && string.IsNullOrEmpty(totalCost))
								{
										sSQL = clsSearchSQL.GetInvoiceWithNum(invoiceNumber);
								}
								else if (!string.IsNullOrEmpty(invoiceNumber) && !string.IsNullOrEmpty(invoiceDate) && string.IsNullOrEmpty(totalCost))
								{
										sSQL = clsSearchSQL.GetInvoicesNumDate(invoiceNumber, invoiceDate);
								}
								else if (!string.IsNullOrEmpty(invoiceNumber) && string.IsNullOrEmpty(invoiceDate) && !string.IsNullOrEmpty(totalCost))
								{
										sSQL = clsSearchSQL.GetInvoicesNumCost(invoiceNumber, totalCost);
								}
								else if (!string.IsNullOrEmpty(invoiceNumber) && !string.IsNullOrEmpty(invoiceDate) && !string.IsNullOrEmpty(totalCost))
								{
										sSQL = clsSearchSQL.GetInvoicesNumDateCost(invoiceNumber, invoiceDate, totalCost);
								}
								else if (string.IsNullOrEmpty(invoiceNumber) && !string.IsNullOrEmpty(invoiceDate) && string.IsNullOrEmpty(totalCost))
								{
										sSQL = clsSearchSQL.GetInvoicesWithDate(invoiceDate);
								}
								else if (string.IsNullOrEmpty(invoiceNumber) && !string.IsNullOrEmpty(invoiceDate) && !string.IsNullOrEmpty(totalCost))
								{
										sSQL = clsSearchSQL.GetInvoicesCostDate(totalCost, invoiceDate);
								}
								int iRetVal = 0;
								DataSet ds = new();
								ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);
								for (int i = 0; i < iRetVal; i++)
								{
										invoices.Add(new clsInvoice(
											ds.Tables[0].Rows[i]["InvoiceNum"].ToString(),
											ds.Tables[0].Rows[i]["InvoiceDate"].ToString(),
											ds.Tables[0].Rows[i]["TotalCost"].ToString()
										));
								}
								return invoices;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}
				#endregion
		}
}