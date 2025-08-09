using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Common
{
	public class clsInvoice
	{
		/// <summary>
		/// Invoice Number
		/// </summary>
		public string sInvoiceNum { get; set; }
		/// <summary>
		/// Invoice date
		/// </summary>
		public string sInvoiceDate { get; set; }
		/// <summary>
		/// Total cost
		/// </summary>
		public string sTotalCost { get; set; }
        /// <summary>
        /// Constructor for clsInvoice
        /// </summary>
        public clsInvoice(string num, string date, string cost)
        {
            try
            {
                sInvoiceNum = num;
                sInvoiceDate = date;
                sTotalCost = cost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                    "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
