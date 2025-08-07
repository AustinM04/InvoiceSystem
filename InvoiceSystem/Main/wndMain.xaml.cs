using InvoiceSystem.Items;
using InvoiceSystem.Search;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InvoiceSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class wndMain : Window
    {
				wndSearch newSearch;
				/// <summary>
				/// Initializes the Main Window
				/// </summary>
				public wndMain()
        {
            InitializeComponent();
						Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
						newSearch = new wndSearch();
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
            wndItems newItems = new wndItems();
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

        }
        /// <summary>
        /// On-Click event for Save Invoice Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// On-Click event for Add Item Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// On-Click event for Remove Item Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Event for when Items combobox is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // After search window is closed, check property SelectedInvoiceID in the search window to see if an invoice is selected. If so load the invoice
        // After Items window is closed, check property HasBeenChanged in the Items window to see if any items were updated. If so re-load items in combo box
    }
}