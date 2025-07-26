using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InvoiceSystem.Items
{
		/// <summary>
		/// Interaction logic for wndItems.xaml
		/// </summary>
		public partial class wndItems : Window
		{
  			//Create an instance for Items SQL Class
  			private Items.clsItemsSQL ItemsSql;
     			
     			public List<Main.clsItems> lstData;
			
			public wndItems()
			{
   				try
       				{
	   				ItemsSql = new Items.clsItemsSQL();
	   				InitializeComponent();
				}
    				catch (Exception ex)
				{
    					throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + 
	 						"." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
				}
				
			}
   			//bool bHasItemsBeenChanged //Set to true when an item has been added/edited/deleted. Used by main window to see if list needs to be refeshed
      			//bool HasItemsBeenChanged //Property
    			
		}
}
