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
        public wndMain()
        {
            InitializeComponent();
        }



























        // After search window is closed, check property SelectedInvoiceID in the search window to see if an invoice is selected. If so load the invoice
        // After Items window is closed, check property HasBeenChanged in the Items window to see if any items were updated. If so re-load items in combo box
    }
}