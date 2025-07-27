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
using System.Windows.Controls.Primitives;

namespace InvoiceSystem
{
    /// <summary>
    /// Class for SQL statements in the Main Window
    /// </summary>
    internal class clsMainSQL
    {
        /// <summary>
        /// Connection string to connect to database
        /// </summary>
        private string sConnectionString;
        /// <summary>
        /// Constructor that sets the connection string to the database
        /// </summary>
        public clsMainSQL()
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
        /// This method takes an SQL statement that is passed in and executes it.  The resulting values
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
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        conn.Open();
                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        adapter.Fill(ds);
                    }
                }
                iRetVal = ds.Tables[0].Rows.Count;
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Updates the Invoices in the database when executed
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="NewCost"></param>
        /// <returns>SQL Statement</returns>
        /// <exception cref="Exception"></exception>
        public static string UpdateInvoice(int InvoiceNum, int NewCost)
        {
            try { return "UPDATE Invoices SET TotalCost = " + NewCost + " WHERE InvoiceNum = " + InvoiceNum; }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Inserts the Item into the database when executed
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="LineItemNum"></param>
        /// <param name="ItemCode"></param>
        /// <returns>SQL Statement</returns>
        /// <exception cref="Exception"></exception>
        public static string InsertItem(int InvoiceNum, int LineItemNum, char ItemCode)
        {
            try 
            { return "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values(" + InvoiceNum + ", " + LineItemNum + ", " + ItemCode + ")"; }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Inserts a new Invoice into the database when executed
        /// </summary>
        /// <param name="InvoiceDate"></param>
        /// <param name="TotalCost"></param>
        /// <returns>SQL Statement</returns>
        /// <exception cref="Exception"></exception>
        public static string InsertInvoice(string InvoiceDate, int TotalCost)
        {
            try
            { return "INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#" + InvoiceDate + "#, " + TotalCost + ")"; }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Selects a specific invoice in the database when executed
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns>SQL Statement</returns>
        /// <exception cref="Exception"></exception>
        public static string ReturnInvoice(int InvoiceNum)
        {
            try { return "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + InvoiceNum; }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Selects all Items in the database when executed
        /// </summary>
        /// <returns>SQL Statement</returns>
        /// <exception cref="Exception"></exception>
        public static string ReturnItems()
        {
            try { return "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc"; }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Selects all items from a specific Invoice from the database when executed
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns>SQL Statement</returns>
        /// <exception cref="Exception"></exception>
        public static string ReturnLineItems(int InvoiceNum)
        {
            try
            {
                return "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost " +
                       "FROM LineItems, ItemDesc " +
                       "WHERE LineItems.ItemCode = ItemDesc.ItemCode AND LineItems.InvoiceNum = " + InvoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Deletes items from an Invoice in the database when executed
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns>SQL Statement</returns>
        /// <exception cref="Exception"></exception>
        public static string DeleteItems(int InvoiceNum)
        {
            try { return "DELETE FROM LineItems WHERE InvoiceNum = " + InvoiceNum; }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
