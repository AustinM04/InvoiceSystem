using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Common
{
	internal class clsInvoice
	{
		//Invoice Number
		int InvoiceID;
		//InvoiceDate
		string InvoiceDate;
		//Total cost
		decimal InvoiceAmount;
		//List<clsItem> Items
		List<clsItem> Items;
	}
}
