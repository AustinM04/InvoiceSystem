using InvoiceSystem.Common;
using System;
using InvoiceSystem;
using System.Windows;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Text;

/// Alex Ng

namespace InvoiceSystem.Items
{
	/// <summary>
	/// Interaction logic for wndItems.xaml
	/// </summary>
	public partial class wndItems : Window
	{
		//Create an instance for Items SQL Class
		private clsItemsLogic itemsLogic;
  		//Create a List to hold item data
		private List<clsItem> clsItems;
		clsItem selectedItem;
		private bool bHasItemsBeenChanged = false; //Set to true when an item has been added/edited/deleted. Used by main window to see if list needs to be refeshed
		///<summary>
		///Constructor
		///</summary>
		public wndItems()
		{
			try
      		{
	   			InitializeComponent();
				itemsLogic = new clsItemsLogic();
				resetDataGrid();
				resetLabels();
			}
    		catch (Exception ex)
			{
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                        MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
		}
   			
      	//bool HasItemsBeenChanged //Property
      	public bool HasItemsBeenChanged
      	{
      		get { return bHasItemsBeenChanged; }
      	}

		/// <summary>
		/// Method to reset the data grid with items from the database
		/// </summary>
		/// <exception cref="Exception"></exception>
		private void resetDataGrid()
		{
			try
			{
   				//DataGrid retreves item data
				dgItems.ItemsSource = itemsLogic.GetItems();
			}
			catch (Exception ex)
			{
   				//Throws Exeception
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		/// <summary>
		/// Method to reset the data grid
		/// </summary>
		private void resetLabels()
		{
			try
			{
   				//All Labels content is returned to zero
				lblCode.Content = "";
				lblDescription.Content = "";
				lblCost.Content = "";
			}
			catch (Exception ex)
			{
   				//Calls HandleError Method for exception
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
						MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}

		/// <summary>
		/// Method to handle the click event of the Add Item button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddItem_Click(object sender, RoutedEventArgs e)
		{
			try
			{
   				//Changes bHasItemsBeenChanged status to True
				bHasItemsBeenChanged = true;

			}
			catch (Exception ex)
			{
   				//Calls HandleError Method for exception
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
					MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}

		/// <summary>
		/// Method to handle the click event of the Add Item button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, RoutedEventArgs e)
		{
			try
			{
   				//Changes bHasItemsBeenChanged status to True
				bHasItemsBeenChanged = true;

			}
			catch (Exception ex)
			{
   				//Calls HandleError Method to handle Error
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
					MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}

		/// <summary>
		/// Method when the Delete Button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			try
			{
   				//Changes bHasItemsBeenChanged status to True
				bHasItemsBeenChanged = true;

			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
						MethodInfo.GetCurrentMethod().Name, ex.Message);
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
   				//Displays Messagebox
				MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
			}
			catch (Exception ex)
			{
				System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + 
					"HandleError Exception: " + ex.Message);
			}
		}

		/// <summary>
		/// Method to make sure that the data grid and labels are reset when the window is loaded
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
   				//Resets the DataGrid
				resetDataGrid();
				//Resets the Labels
				resetLabels();
			}
			catch (Exception ex)
			{
   				//Calls HandelError method to handle error
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
					MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}

		/// <summary>
		/// Method to handle the selection changed event of the data grid and update the labels with selected item details
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			try
			{
   				//If items in data grid is not null
				if (dgItems.SelectedItem != null)
				{
					//All Selected content is displayed
					selectedItem = (clsItem)dgItems.SelectedItem;
					lblCode.Content = selectedItem.sItemCode;
					lblDescription.Content = selectedItem.sDescription;
					lblCost.Content = selectedItem.sCost;
				}
			}
			catch (Exception ex)
			{
   				//Calls HandleError Method to handle error
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
					MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}
	}
}
