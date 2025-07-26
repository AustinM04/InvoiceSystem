using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Items
{
    public class clsItemsSQL
	{
        /// <summary>
        /// Holds an SQL statement
        /// </summary>
        public string sSQL;

        /// <summary>
        /// Creates an instance of the DataAccess class
        /// </summary>
        //private clsDataAccess db;

        /// <summary>
        /// Create a list to hold the list items
        /// </summary>
        //public List<clsItems> lstItems { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public clsItemsSQL()
        {
            try
            {
                //lstItems = new List<clsItems>();
            }
            catch (Exception ex)
            {
                //Throws Exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + 
                    "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Gets the Item Description
        /// </summary>
        /// <returns></returns>
        //public List<clsItems> GetItemDesc()
        //{
            //try
            //{
                //db = new clsDataAccess();

                //int iRet = 0;   //Number of return values
                //DataSet ds = new DataSet(); //Holds the return values

                //ds.AcceptChanges();

                //clsItems Items;
                //sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc ";

                //Extract the passengers and put them into the DataSet
                //ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                //lstItems = new List<clsItems>();
                //for (int i = 0; i < iRet; i++)
                //{
                //    Items = new clsItems();
                //    Items.ItemCode = ds.Tables[0].Rows[i]["ItemCode"].ToString();
                //    Items.ItemDesc = ds.Tables[0].Rows[i]["ItemDesc"].ToString();
                //    Items.ItemCost = ds.Tables[0].Rows[i]["Cost"].ToString();

                //    lstItems.Add(Items);
                //}

                //return lstItems;
            //}
            //catch (Exception ex)
            //{
                //Just throw the exception
                //throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                //                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            //}
        //}
    }
}
