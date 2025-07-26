using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace InvoiceSystem.Search
{
		internal class clsSearchSQL
		{
				// Provided sql statements
				//- SELECT * FROM Invoices
				//- SELECT * FROM Invoices WHERE InvoiceNum = 5000
				//- SELECT * FROM Invoices WHERE InvoiceNum = 5000 AND InvoiceDate = #4/13/2018#
				//- SELECT * FROM Invoices WHERE InvoiceNum = 5000 AND InvoiceDate = #4/13/2018# AND TotalCost = 120
				//- SELECT * FROM Invoices WHERE TotalCost = 1200
				//- SELECT * FROM Invoices WHERE TotalCost = 1300 and InvoiceDate = #4/13/2018# 
				//- SELECT * FROM Invoices WHERE InvoiceDate = #4/13/2018#

				// These next three are used to get distinct values for the combo boxes
				//- SELECT DISTINCT(InvoiceNum) From Invoices order by InvoiceNum
				//- SELECT DISTINCT(InvoiceDate) From Invoices order by InvoiceDate
				//- SELECT DISTINCT(TotalCost) From Invoices order by TotalCost

				/// <summary>
				/// Gets all the Invoices from the database
				/// </summary>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetAllInvoices()
				{
						try
						{
								string sSQL = "SELECT * FROM Invoices";
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoices from the database with a specific Invoice Number
				/// </summary>
				/// <param name="invNum">Invoice number</param>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetInvoiceWithNum(string invNum)
				{
						try
						{
								string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + invNum;
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoices from the database with a specific invoice number and invoice date
				/// </summary>
				/// <param name="invNum">Invoice number</param>
				/// <param name="invDate">Invoice date</param>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetInvoicesNumDate(string invNum, string invDate)
				{
						try
						{
								string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + invNum + " AND InvoiceDate = #" + invDate + "#";
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoices from the database matchin the invoice number, invoice date and total cost
				/// </summary>
				/// <param name="invNum">Invoice number</param>
				/// <param name="invDate">Invoice date</param>
				/// <param name="invCost">Invoice total cost</param>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetInvoicesNumDateCost(string invNum, string invDate, string invCost)
				{
						try
						{
								string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + invNum + " AND InvoiceDate = #" + invDate + "# AND TotalCost = " + invCost;
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoices from the database with a specific Total Cost
				/// </summary>
				/// <param name="invCost">Invoice total cost</param>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetInvoicesWithCost(string invCost)
				{
						try
						{
								string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + invCost;
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoices from the database with a specific total cost and invoice date
				/// </summary>
				/// <param name="invCost">Invoice total cost</param>
				/// <param name="invDate">Invoice date</param>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetInvoicesCostDate(string invCost, string invDate)
				{
						try
						{
								string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + invCost + " AND InvoiceDate = #" + invDate + "#";
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoices from the database matching given invoice date
				/// </summary>
				/// <param name="invDate">Invoice date</param>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetInvoicesWithDate(string invDate)
				{
						try
						{
								string sSQL = "SELECT * FROM Invoices WHERE InvoiceDate = #" + invDate + "#";
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoice numbers from the database
				/// </summary>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetAllInvoiceNums()
				{
						try
						{
								string sSQL = "SELECT DISTINCT(InvoiceNum) From Invoices order by InvoiceNum";
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoice dates from the database
				/// </summary>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetAllInvoiceDates()
				{
						try
						{
								string sSQL = "SELECT DISTINCT(InvoiceDate) From Invoices order by InvoiceDate";
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoice total costs from the database
				/// </summary>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetAllInvoiceTotals()
				{
						try
						{
								string sSQL = "SELECT DISTINCT(TotalCost) From Invoices order by TotalCost";
								return sSQL;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}
		}
}
