using System;
using InvoiceSystem;
using System.Windows;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

/// Austin Moore

namespace InvoiceSystem.Search
{
		/// <summary>
		/// Interaction logic for wndSearch.xaml
		/// </summary>
		public partial class wndSearch : Window
		{
				#region class variables
				/// <summary>
				/// Search logic instance to handle the search operations
				/// </summary>
				private clsSearchLogic searchLogic;

				/// <summary>
				/// sSelectedInvoiceID - Holds the invoice ID if the user selected one, and 0 if no invoice is selected
				/// sSelectedInvoiceID - Property main window can access to get to the selected invoice ID
				/// </summary>
				public string sSelectedInvoiceID { get; private set; }

				#endregion

				#region initialization
				/// <summary>
				/// Initializes the Search Window
				/// </summary>
				public wndSearch()
				{
						try
						{
								InitializeComponent();
								searchLogic = new clsSearchLogic();
								resetComboBoxes();
								resetDataGrid();
						}
						catch (Exception ex)
						{
								HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
										MethodInfo.GetCurrentMethod().Name, ex.Message);
						}
				}
				#endregion

				#region button event handlers
				/// <summary>
				/// Method to handle the selection of an invoice from the DataGrid
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void btnSelectInvoice_Click(object sender, RoutedEventArgs e)
				{
						try
						{
								if (dgInvoices.SelectedItem != null)
								{
										// Get the selected invoice ID from the DataGrid
										var selectedInvoice = (Common.clsInvoice)dgInvoices.SelectedItem;
										if (selectedInvoice != null)
										{
												sSelectedInvoiceID = selectedInvoice.sInvoiceNum;
										}
										MessageBox.Show($"Selected InvoiceID: {sSelectedInvoiceID}");

										this.DialogResult = true;
										this.Close();
								}
								else
								{
										MessageBox.Show("Please select an invoice first.");
								}
								
						}
						catch (Exception ex)
						{
								HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
										MethodInfo.GetCurrentMethod().Name, ex.Message);
						}

				}

				/// <summary>
				/// Method to clear the filters and reset the combo boxes and DataGrid
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void btnClearFilter_Click(object sender, RoutedEventArgs e)
				{
						try
						{
								resetComboBoxes();
								resetDataGrid();
								sSelectedInvoiceID = "0";
						}
						catch (Exception ex)
						{
								HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
										MethodInfo.GetCurrentMethod().Name, ex.Message);
						}
				}

				/// <summary>
				/// Method to refresh the DataGrid with the current search criteria when the combo boxes are changed
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void comboBox_Changed(object sender, SelectionChangedEventArgs e)
				{
						try
						{
								resetDataGrid();
						}
						catch (Exception ex)
						{
								HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
										MethodInfo.GetCurrentMethod().Name, ex.Message);
						}
				}

				/// <summary>
				/// Method to reset the view when the search window is reloaded 
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void Window_Loaded(object sender, RoutedEventArgs e)
				{
						try
						{
								resetComboBoxes();
								resetDataGrid();
						}
						catch (Exception ex)
						{
								HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
										MethodInfo.GetCurrentMethod().Name, ex.Message);
						}
				}
				#endregion

				#region helper methods
				/// <summary>
				/// Method to reset the combo boxes with the distinct values from the database
				/// </summary>
				/// <exception cref="Exception"></exception>
				private void resetComboBoxes()
				{
						try
						{
								cbInvoiceNumber.ItemsSource = searchLogic.GetDistinctInvoiceNumbers();
								cbInvoiceDate.ItemsSource = searchLogic.GetDistinctDates();
								cbInvoiceCost.ItemsSource = searchLogic.GetDistinctCosts();
								cbInvoiceCost.SelectedIndex = -1;
								cbInvoiceDate.SelectedIndex = -1;
								cbInvoiceNumber.SelectedIndex = -1;
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}

				}
				

				
				/// <summary>
				/// Method to reset the DataGrid with the current search criteria
				/// </summary>
				/// <exception cref="Exception"></exception>
				private void resetDataGrid()
				{
						try
						{
								dgInvoices.ItemsSource = searchLogic.GetInvoices(
								cbInvoiceNumber.SelectedItem as string,
								cbInvoiceDate.SelectedItem as string,
								cbInvoiceCost.SelectedItem as string);
						}
						catch (Exception ex)
						{
								throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
						}

				}
				

				#region try-catch block copy paste
				//try
				//{

				//}
				//catch (Exception ex)
				//{
				//		HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
				//								MethodInfo.GetCurrentMethod().Name, ex.Message);
				//}
				#endregion

				/// <summary>
				/// Handle the error.
				/// </summary>
				/// <param name="sClass">The class in which the error occurred in.</param>
				/// <param name="sMethod">The method in which the error occurred in.</param>
				private void HandleError(string sClass, string sMethod, string sMessage)
				{
						try
						{
								MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
						}
						catch (Exception ex)
						{
								System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
										"HandleError Exception: " + ex.Message);
						}
				}
				#endregion

		}
}