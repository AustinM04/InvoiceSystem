using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Search
{
		public class clsSearchSQL
		{
				#region SQL Query methods
				/// <summary>
				/// Gets all the Invoices from the database
				/// </summary>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetAllInvoices()
				{
						try
						{
								return "SELECT * FROM Invoices";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								return $"SELECT * FROM Invoices WHERE InvoiceNum = {invNum}";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								return $"SELECT * FROM Invoices WHERE InvoiceNum = {invNum} AND InvoiceDate = #{invDate}#";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoices from the database matching the invoice number, invoice date and total cost
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
								return $"SELECT * FROM Invoices WHERE InvoiceNum = {invNum} AND InvoiceDate = #{invDate}# AND TotalCost = {invCost}";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}

				/// <summary>
				/// Gets all the Invoices from the database matching the invoice number and total cost
				/// </summary>
				/// <param name="invNum">Invoice number</param>
				/// <param name="invCost">Invoice total cost</param>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetInvoicesNumCost(string invNum, string invCost)
				{
						try
						{
								return $"SELECT * FROM Invoices WHERE InvoiceNum = {invNum} AND TotalCost = {invCost}";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								return $"SELECT * FROM Invoices WHERE TotalCost = {invCost}";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								return "SELECT * FROM Invoices WHERE TotalCost = " + invCost + " AND InvoiceDate = #" + invDate + "#";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								return $"SELECT * FROM Invoices WHERE InvoiceDate = #{invDate}#";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}
				#region get distinct values
				/// <summary>
				/// Gets all the Invoice numbers from the database
				/// </summary>
				/// <returns>SQL query string</returns>
				/// <exception cref="Exception"></exception>
				public static string GetAllInvoiceNums()
				{
						try
						{
								return "SELECT DISTINCT(InvoiceNum) From Invoices order by InvoiceNum";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								return "SELECT DISTINCT(InvoiceDate) From Invoices order by InvoiceDate";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
								return "SELECT DISTINCT(TotalCost) From Invoices order by TotalCost";
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
									MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}
				}
				#endregion

				#endregion
		}
}
