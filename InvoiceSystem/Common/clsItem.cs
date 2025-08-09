using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Common
{
	public class clsItem
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
        public clsItem(string code, string desc, string cost)
        {
            try
            {
                sItemCode = code;
                sDescription = desc;
                sCost = cost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                    "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
