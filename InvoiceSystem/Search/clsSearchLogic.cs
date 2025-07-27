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

namespace InvoiceSystem.Search
{
		/// <summary>
		/// Interaction logic for the wndSearch.xaml
		/// </summary>
		internal class clsSearchLogic
		{
				/// <summary>
				/// Connection string to the database.
				/// </summary>
				private string sConnectionString;
				/// <summary>
				/// Constructor that sets the connection string to the database
				/// </summary>
				public clsSearchLogic()
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

				public List<string> GetDistinctInvoiceNumbers()
				{
						// This method will get the sql string to get all invoice numbers then it will use the
						//		 data access class to get the dataset of the values once that has been set up
						// For now, we will return a mock list of invoice numbers.
						try
						{
								string sSQL = clsSearchSQL.GetAllInvoiceNums();
								List<string> nums = new();
								int iRetVal = 0;
								DataSet ds = new();
								ds = ExecuteSQLStatement(sSQL, ref iRetVal);
								for (int i = 0; i < iRetVal; i++)
								{
										nums.Add(ds.Tables[0].Rows[i]["InvoiceNum"].ToString());
								}
								return nums;
								//return new List<string> { "INV001", "INV002", "INV003" };
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
						
				}

				public List<string> GetDistinctDates()
				{
						// This method will get the sql string to get all invoice dates then it will use the
						//		 data access class to get the dataset of the values once that has been set up
						// For now, we will return a mock list of invoice dates.
						try
						{
								string sSQL = clsSearchSQL.GetAllInvoiceDates();
								List<string> dates = new();
								int iRetVal = 0;
								DataSet ds = new();
								ds = ExecuteSQLStatement(sSQL, ref iRetVal);
								for (int i = 0; i < iRetVal; i++)
								{
										dates.Add(ds.Tables[0].Rows[i]["InvoiceDate"].ToString());
								}
								return dates;
								//return new List<string> { "2023-01-01", "2023-02-01", "2023-03-01" };
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
						
						
				}

				public List<string> GetDistinctCosts()
				{
						// This method would typically interact with a database or data source
						// to retrieve distinct total costs.
						// For now, we will return a mock list of total costs.
						try
						{
								string sSQL = clsSearchSQL.GetAllInvoiceTotals();
								List<string> costs = new();
								int iRetVal = 0;
								DataSet ds = new();
								ds = ExecuteSQLStatement(sSQL, ref iRetVal);
								for (int i = 0; i < iRetVal; i++)
								{
										costs.Add(ds.Tables[0].Rows[i]["TotalCost"].ToString());
								}
								return costs;
								//return new List<string> { "100.00", "200.00", "300.00" };
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}
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
								ds = ExecuteSQLStatement(sSQL, ref iRetVal);
								for (int i = 0; i < iRetVal; i++)
								{
										invoices.Add(new clsInvoice()
										{
												sInvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString(),
												sInvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString(),
												sTotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString()
										});
								}
								return invoices;
								// For now, we will return a mock list of invoices.
								//return new List<clsInvoice>
								//{
								//		new clsInvoice { sInvoiceNum = "1", sInvoiceDate = "2025-01-01", sTotalCost = "100.00" },
								//		new clsInvoice { sInvoiceNum = "2", sInvoiceDate = "2025-02-01", sTotalCost = "200.00" },
								//		new clsInvoice { sInvoiceNum = "3", sInvoiceDate = "2025-03-01", sTotalCost = "300.00" }
								//};
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
						
				}
		}
}
