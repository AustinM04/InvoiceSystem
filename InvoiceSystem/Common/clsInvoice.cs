using System.Reflection;

namespace InvoiceSystem
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
