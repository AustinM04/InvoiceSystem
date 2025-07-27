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
		public int iItemCode { get; set; }
		/// <summary>
		/// Item Description
		/// </summary>
		public string sDescription { get; set; }
		/// <summary>
		/// Item Cost
		/// </summary>
		public decimal dCost { get; set; }
	}
}
