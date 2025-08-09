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

namespace InvoiceSystem.Main
{
    /// <summary>
    /// Class for containing the database connection logic
    /// </summary>
	public class clsMainLogic
	{
        /// <summary>
        /// Returns all Items from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<clsItem> GetAllItems()
        {
            try
            {
                var items = new List<clsItem>();
                int rowCount = 0;
                var ds = new DataSet();
                clsDataAccess db = new clsDataAccess();
                ds = db.ExecuteSQLStatement(clsMainSQL.ReturnItems(), ref rowCount);
                
                for (int i = 0; i < rowCount; i++)
                {
                    var row = ds.Tables[0].Rows[i];
                    items.Add(new clsItem(
                        row["ItemCode"].ToString(),
                        row["ItemDesc"].ToString(),
                        row["Cost"].ToString()
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
        /// Inserts a new Invoice into the database
        /// </summary>
        /// <param name="invoice"></param>
        /// <exception cref="Exception"></exception>
        public static void SaveNewInvoice(clsInvoice invoice)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                db.ExecuteNonQuery(clsMainSQL.InsertInvoice(invoice.sInvoiceDate, invoice.sTotalCost));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Changes the cost of an invoice
        /// </summary>
        /// <param name="invNum"></param>
        /// <param name="newCost"></param>
        /// <exception cref="Exception"></exception>
        public static void EditInvoice(string invNum, string newCost)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                db.ExecuteNonQuery(clsMainSQL.UpdateInvoice(invNum, newCost));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Returns an invoice based on the invoice number
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static clsInvoice GetInvoice(string invoiceNumber)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                int rowCount = 0;
                ds = db.ExecuteSQLStatement(invoiceNumber, ref rowCount);
                clsInvoice retInvoice = null;
                for (int i = 0; i < rowCount; i++)
                {
                    var row = ds.Tables[0].Rows[i];
                    retInvoice = new clsInvoice(
                        row["InvoiceNum"].ToString(),
                        row["InvoiceDate"].ToString(),
                        row["TotalCost"].ToString()
                    );
                }
                return retInvoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Deletes an invoice from the database
        /// </summary>
        /// <param name="invoice"></param>
        /// <exception cref="Exception"></exception>
        public static void DeleteInvoice(clsInvoice invoice)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                db.ExecuteScalarSQL(clsMainSQL.DeleteItems(invoice.sInvoiceNum.ToString()));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}