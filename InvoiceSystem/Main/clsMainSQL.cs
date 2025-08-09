using System.Reflection;

namespace InvoiceSystem.Main
{
    /// <summary>
    /// Class for SQL statements in the Main Window
    /// </summary>
    public class clsMainSQL
    {
        /// <summary>
        /// Updates the Invoices in the database when executed
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="NewCost"></param>
        /// <returns>SQL Statement</returns>
        /// <exception cref="Exception"></exception>
        public static string UpdateInvoice(string InvoiceNum, string NewCost)
        {
            try
            {
                return $"UPDATE Invoices SET TotalCost = {NewCost} WHERE InvoiceNum = {InvoiceNum}";
            }
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
        public static string InsertItem(string InvoiceNum, string LineItemNum, string ItemCode)
        {
            try 
            { 
                return $"INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values({InvoiceNum}, {LineItemNum}, {ItemCode})";
            }
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
        public static string InsertInvoice(string InvoiceDate, string TotalCost)
        {
            try
            { 
                return $"INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#{InvoiceDate}#, {TotalCost})";
            }
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
        public static string ReturnInvoice(string InvoiceNum)
        {
            try 
            { 
                return $"SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = {InvoiceNum}";
            }
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
            try 
            { 
                return "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
            }
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
        public static string ReturnLineItems(string InvoiceNum)
        {
            try
            {
                return $"SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc WHERE LineItems.ItemCode = ItemDesc.ItemCode AND LineItems.InvoiceNum = {InvoiceNum}";
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
        public static string DeleteItems(string InvoiceNum)
        {
            try 
            { 
                return "DELETE FROM LineItems WHERE InvoiceNum = {InvoiceNum}";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
