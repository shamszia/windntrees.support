using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using System.Windows.Shapes;
using WindnTrees.ICRUDS;

namespace ApplicationWPF.Products
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        private int ListNumber { get; set; }
        private int ListSize { get; set; }

        #region GetServiceAddress
        /// <summary>
        /// Gets service address.
        /// </summary>
        /// <returns></returns>
        public string GetServiceAddress(string relatedAddress)
        {
            return string.Format("net.tcp://{0}:{1}/{2}", ConfigurationManager.AppSettings["IPAddress"], ConfigurationManager.AppSettings["TCPPort"], relatedAddress);
        }
        #endregion

        #region ProductServiceClient
        private WCFServiceClient<Application.Models.Standard.DataAccess.Adapter.Product> m_ProductServiceClient = null;
        /// <summary>
        /// Product service client.
        /// </summary>
        private WCFServiceClient<Application.Models.Standard.DataAccess.Adapter.Product> ProductServiceClient
        {
            get
            {
                if (m_ProductServiceClient == null)
                {
                    m_ProductServiceClient = new WCFServiceClient<Application.Models.Standard.DataAccess.Adapter.Product>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Adapter.Product>.GetTcpWCFChannelAsyncFactory(GetServiceAddress("adapter/product")));
                }
                return m_ProductServiceClient;
            }
        }
        #endregion

        public ListWindow()
        {
            InitializeComponent();
            ListNumber = 1;
            ListSize = 10;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListProducts();
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            ListProducts();
        }

        private void ListProducts()
        {
            StatusTextBlock.Text = "Listing...";
            ProductServiceClient.BeginMethodSearchObject(new SearchInput { keyword = KeywordTextBox.Text, page = ListNumber, size = ListSize }, "ListTotal", new AsyncCallback(Product_ListTotalCallback), null);
            ProductServiceClient.BeginList(new SearchInput { keyword = KeywordTextBox.Text, page = ListNumber, size = ListSize }, new AsyncCallback(Product_ListCallback), null);
        }

        private void Product_ListTotalCallback(IAsyncResult asyncResult)
        {
            try
            {
                int productsListTotal = (int)ProductServiceClient.EndMethodSearchObject(asyncResult);
                int totalPages = (productsListTotal / ListSize) + ((productsListTotal % ListSize) > 0 ? 1 : 0);
                Dispatcher.BeginInvoke(new Action(() => {
                    TotalListsTextBox.Content = string.Format("/{0}", totalPages);
                }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Product_ListCallback(IAsyncResult asyncResult)
        {
            try
            {
                List<Application.Models.Standard.DataAccess.Adapter.Product> productsList = ProductServiceClient.EndList(asyncResult);
                Dispatcher.BeginInvoke(new Action(() => {
                    StatusTextBlock.Text = "Completed";
                    ProductsDataGrid.ItemsSource = productsList;
                }));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var newProductWindow = new NewWindow();
            newProductWindow.DataContext = new Application.Models.Standard.DataAccess.Adapter.Product { Name = "New Product" };
            newProductWindow.ShowDialog();
            if (newProductWindow.DialogResult != null)
            {
                if ((bool)newProductWindow.DialogResult)
                {
                    StatusTextBlock.Text = "Creating...";
                    ProductServiceClient.BeginCreate((Application.Models.Standard.DataAccess.Adapter.Product)newProductWindow.DataContext, new AsyncCallback(Product_CreateCallback), null);
                }
            }
        }

        private void Product_CreateCallback(IAsyncResult asyncResult)
        {
            var newProduct = ProductServiceClient.EndCreate(asyncResult);
            Dispatcher.BeginInvoke(new Action(() => {
                StatusTextBlock.Text = "Completed";
                ListProducts();
            }));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                var editProductWindow = new EditWindow();
                editProductWindow.DataContext = ProductsDataGrid.SelectedItem;
                editProductWindow.ShowDialog();

                if (editProductWindow.DialogResult != null)
                {
                    if ((bool)editProductWindow.DialogResult) {

                        StatusTextBlock.Text = "Updating...";
                        ProductServiceClient.BeginUpdate((Application.Models.Standard.DataAccess.Adapter.Product)editProductWindow.DataContext, new AsyncCallback(Product_UpdateCallback), null);
                    }
                }       
            }
        }

        private void Product_UpdateCallback(IAsyncResult asyncResult)
        {
            var updatedProduct = ProductServiceClient.EndUpdate(asyncResult);

            Dispatcher.BeginInvoke(new Action(() => {
                StatusTextBlock.Text = "Completed";
                ListProducts();
            }));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Are you sure to delete selected record?", "Confirm Deletion", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {   
                    StatusTextBlock.Text = "Deleting...";
                    Application.Models.Standard.DataAccess.Adapter.Product product = (Application.Models.Standard.DataAccess.Adapter.Product)ProductsDataGrid.SelectedItem;
                    ProductServiceClient.BeginDelete(product, new AsyncCallback(Product_DeleteCallback), null);
                }
            }
        }

        private void Product_DeleteCallback(IAsyncResult asyncResult)
        {
            var deletedProduct = ProductServiceClient.EndDelete(asyncResult);

            Dispatcher.BeginInvoke(new Action(() => {
                StatusTextBlock.Text = "Completed";
                ListProducts();
            }));
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            ListNumber--;
            ListNumberTextBox.Text = ListNumber.ToString();

            ListProducts();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ListNumber++;
            ListNumberTextBox.Text = ListNumber.ToString();

            ListProducts();
        }

        private void ListNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListNumber = int.Parse(ListNumberTextBox.Text);

            if (KeywordTextBox != null)
            {
                ListProducts();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ProductsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                StatusTextBlock.Text = "Reading...";
                ProductServiceClient.BeginRead(((Application.Models.Standard.DataAccess.Adapter.Product)ProductsDataGrid.SelectedItem).UID.ToString(), new AsyncCallback(Product_ReadCallback), null);
            }
        }

        private void Product_ReadCallback(IAsyncResult asyncResult)
        {
            var readProduct = ProductServiceClient.EndRead(asyncResult);
            Dispatcher.BeginInvoke(new Action(() => {
                StatusTextBlock.Text = "Completed";

                var viewProductWindow = new ViewWindow();
                viewProductWindow.DataContext = readProduct;
                viewProductWindow.ShowDialog();
            }));
        }
    }
}
