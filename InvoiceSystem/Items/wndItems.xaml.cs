using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        //a list to hold Items data

        /// <summary>
        /// Constructor for Window
        /// </summary>
        /// <exception cref="Exception"></exception>
        public wndItems()
	    {
            try
            {
                ItemsSql = new Items.clsItemsSQL();
                InitializeComponent();
                updateItem();
                dealWithDataGrid();
            }
            catch (Exception ex)
            {
                //Throws Exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + 
                    "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Data Input for DataGrid
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void dealWithDataGrid()
        {
            try
            {
                //Items Placed in Data Grid
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// When the Add Button is Pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Items are added to list
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// When the Edit Button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //This will edit an item
            }
            catch (Exception ex) 
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Updates the list by using items SQL class
        /// </summary>
        public void updateItem()
        {
            try
            {
                //Updates Item
                //lstData = ItemsSql.GetItemDesc();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
        /// <summary>
        /// Delete Button is Pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            try 
            { 
                //Item is deleted
            } 
            catch (Exception ex) 
            {
                //Exception is issued to HandleError Method
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        //bool bHasItemsBeenChanged //Set to true when an item has been added/edited/deleted. Used by main window to see if list needs to be refeshed
        //bool HasItemsBeenChanged //Property

    }
}
