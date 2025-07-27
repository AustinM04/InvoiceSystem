using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Items
{
		internal class clsItemsSQL
		{
				//- select ItemCode, ItemDesc, Cost from ItemDesc
				//- select distinct(InvoiceNum) from LineItems where ItemCode = 'A'
				//- Update ItemDesc Set ItemDesc = 'abcdef', Cost = 123 where ItemCode = 'A'
				//- Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('ABC', 'blah', 321)
				//- Delete from ItemDesc Where ItemCode = 'ABC'

				/// <summary>
				/// This SQL gets all item details
				/// </summary>
				/// <returns>All data for the given invoice.</returns>
				public static string GetAllItemDetails()
				{
						string sSQL = "SELECT ItemCode, ItemDesc, Cost from ItemDesc";
						return sSQL;
				}


				/// <summary>
				/// This SQL gets all the invoices that contain a specific item code.
				/// </summary>
				/// <param name="itemCode">The item code to retrieve all invoices for.</param>
				/// <returns>All invoices for the given item code.</returns>
				public static string GetItemWithCode(string itemCode)
				{
						string sSQL = $"SELECT distinct(InvoiceNum) from LineItems where ItemCode = '{itemCode}'";
						return sSQL;
				}

				/// <summary>
				/// SQL to update existing item
				/// </summary>
				public static string UpdateItem(string itemDesc, string itemCost, string itemCode)
				{
						return $"Update ItemDesc Set ItemDesc = '{itemDesc}', Cost = {itemCost} where ItemCode = '{itemCode}'";
				}


				/// <summary>
				/// This SQL inserts a new item into the ItemDesc table
				/// </summary>
				/// <param name="itemCode">Item code for the new item</param>
				/// <param name="itemDesc">Description for the new item</param>
				/// <param name="itemPrice">Price for the new item</param>
				/// <returns></returns>
				public static string InsertItem(string itemCode, string itemDesc, string itemPrice)
				{
						return $"Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('{itemCode}', '{itemDesc}', {itemPrice});";
				}


				/// <summary>
				/// This SQL deletes an item from the ItemDesc table based on the item code
				/// </summary>
				/// <param name="itemCode"></param>
				/// <returns></returns>
				public static string DeleteItem(string itemCode)
				{
						return $"Delete from ItemDesc Where ItemCode = '{itemCode}';";
				}
		}
}
