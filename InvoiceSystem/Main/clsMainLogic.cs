using InvoiceSystem;
using System;
using System.Windows;
using System.Reflection;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Data;

namespace InvoiceSystem
{
    /// <summary>
    /// 
    /// </summary>
	public class clsMainLogic
	{
        /// <summary>
        /// 
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
                        row["Flight_Number"].ToString(),
                        row["Aircraft_Type"].ToString()
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
        public static void EditInvoice(clsInvoice oldInvoice, clsInvoice newInvoice)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                // Logic to edit an existing invoice
                // This would typically involve updating the invoice details in the database
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        public static clsInvoice GetInvoice(string invoiceNumber)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                // Logic to retrieve an invoice by its number
                // This would typically involve querying the database for the invoice details
                return new clsInvoice(); // Placeholder return, replace with actual retrieval logic
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        public static void DeleteInvoice(clsInvoice invoice)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                // Logic to delete an invoice
                // This would typically involve removing the invoice details from the database
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}