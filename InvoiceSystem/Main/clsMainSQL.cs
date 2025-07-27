using InvoiceSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace InvoiceSystem.Main
{
    internal class clsMainSQL
    {
        public static string UpdateInvoice(int InvoiceNum, int NewCost)
        {
            try { return "UPDATE Invoices SET TotalCost = " + NewCost + " WHERE InvoiceNum = " + InvoiceNum; }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
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
        public static string ReturnInvoice(int InvoiceNum)
        {
            try { return "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + InvoiceNum; }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        public static string ReturnItems()
        {
            try { return "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc"; }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
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
