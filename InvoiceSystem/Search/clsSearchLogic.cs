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
		/// <summary>
		/// Declaring a new instance of the data access class to interact with the database
		/// </summary>
		clsDataAccess db = new clsDataAccess();
		
		public List<string> GetDistinctInvoiceNumbers()
		{
			// This method will get the sql string to get all invoice numbers then it will use the
			// data access class to get the dataset of the values once that has been set up
			// For now, we will return a mock list of invoice numbers.
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
				ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);
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
				ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);
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