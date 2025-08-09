using System;
using InvoiceSystem;
using InvoiceSystem.Common;
using InvoiceSystem.Main;
using InvoiceSystem.Search;
using InvoiceSystem.Items;
using System.Windows;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

/// Marley Palmer
/// Austin Moore
/// Alex Ng

namespace InvoiceSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// Initializing the search window
        /// </summary>
	    wndSearch newSearch = new wndSearch();

		/// <summary>
		/// Initializes the Main Window
		/// </summary>
	    public wndMain()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                cboItems.ItemsSource = clsMainLogic.GetAllItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// On-Click event for Search Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            newSearch.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// On-Click event for Edit Items Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Items.wndItems newItems = new wndItems();
            newItems.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// On-Click event for Edit Invoice Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInvoice_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// On-Click event for Save Invoice Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// On-Click event for Add Item Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsItem selectedItem = (clsItem)cboItems.SelectedItem;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// On-Click event for Remove Item Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Event for when Items combobox is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                lblCost.Content = "Cost: " + ((clsItem)cboItems.SelectedItem).sCost;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void gItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        // After search window is closed, check property SelectedInvoiceID in the search window to see if an invoice is selected. If so load the invoice
        // After Items window is closed, check property HasBeenChanged in the Items window to see if any items were updated. If so re-load items in combo box
    }
}