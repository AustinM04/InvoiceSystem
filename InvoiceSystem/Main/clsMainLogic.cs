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

namespace InvoiceSystem
{
	internal class clsMainLogic
	{
        public static List<clsItem> GetAllItems()
        {
            try
            {
                var items = new List<clsItem>();
                int rowCount = 0;

                var db = new clsMainSQL();

                var ds = db.ExecuteSQLStatement(clsMainSQL.ReturnItems(), ref rowCount);

                for (int i = 0; i < rowCount; i++)
                {
                    var row = ds.Tables[0].Rows[i];
                    items.Add(new clsItem
                    {
                        sItemCode = row["ItemCode"].ToString(),
                        sDescription = row["Flight_Number"].ToString(),
                        sCost = row["Aircraft_Type"].ToString()
                    });
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        //SaveNewInvoice(clsInvoice)
        //EditInvoice(clsInvoice old, clsInvoice new)
        //GetInvoice(InvoiceNumber) returns clsInvoice - Get the invoice and items for the selected invoice from search window
    }
}
