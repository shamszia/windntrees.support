using ApplicationWPF.Products;
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

namespace ApplicationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ButtonManageProducts_Click(object sender, RoutedEventArgs e)
        {
            var productListWindow = new ListWindow();
            productListWindow.Show();
        }
        private void ButtonManageCRUDViewProducts_Click(object sender, RoutedEventArgs e)
        {
            var productListWindow = new ApplicationWPF.Products.CRUDViewListWindow();
            productListWindow.Show();
        }

        private void ButtonManageEmptyCRUDViewProducts_Click(object sender, RoutedEventArgs e)
        {
            var productListWindow = new ApplicationWPF.EmptyProduct.CRUDViewListWindow();
            productListWindow.Show();
        }
    }
}
