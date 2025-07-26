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
				public int ItemCode { get; set; }
				/// <summary>
				/// Item Description
				/// </summary>
				public string Description { get; set; }
				/// <summary>
				/// Item Cost
				/// </summary>
				public decimal Cost { get; set; }
		}
}
