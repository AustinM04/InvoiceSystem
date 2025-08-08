using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Common
{
	internal class clsItem
	{
		/// <summary>
		/// Item Code
		/// </summary>
		public string sItemCode { get; set; }
		/// <summary>
		/// Item Description
		/// </summary>
		public string sDescription { get; set; }
		/// <summary>
		/// Item Cost
		/// </summary>
		public string sCost { get; set; }
		/// <summary>
        /// Constructor
        /// </summary>
        public clsItem(string sitemDesc, string sitemCode, string sitemCost) 
        {
            try
            {
                sDescription = sitemDesc;
                sItemCode = sitemCode;
                sCost = sitemCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + 
                    "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
		///<summary>
		///Override ToString Method
		///</summary>
		public override string ToString()
        {
            try
            {
                return sDescription;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + 
                                    ex.Message);
            }
        }
	}
}
