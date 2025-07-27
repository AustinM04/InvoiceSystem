using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Common
{
	internal class clsInvoice
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
		/// List of items in the invoice
		/// </summary>
		public List<clsItem> Items { get; set; }
	}
}
