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
using Application.Models.Standard.DataAccess.Adapter;
using WindnTrees.ICRUDS.Standard;
using WindnTrees.ICRUDS.Standard.Controller;
using WindnTrees.ICRUDS.Standard.Processor;
using WindnTrees.ICRUDS.Standard.Model;
using WindnTrees.ICRUDS.Standard.Views;
using ApplicationWPFCore.ViewModels;
using System.ServiceModel.Security;

namespace ApplicationWPFCore.Products
{
    /// <summary>
    /// Interaction logic for CRUDViewListWindow.xaml
    /// </summary>
    public partial class CRUDViewListWindow : Window
    {
        public static RoutedCommand StaticCreateCommand = new RoutedCommand();
        public static RoutedCommand StaticReadCommand = new RoutedCommand();
        public static RoutedCommand StaticEditCommand = new RoutedCommand();
        public static RoutedCommand StaticDeleteCommand = new RoutedCommand();
        public static RoutedCommand StaticListCommand = new RoutedCommand();
        public static RoutedCommand StaticNextCommand = new RoutedCommand();
        public static RoutedCommand StaticPrevCommand = new RoutedCommand();
        public static RoutedCommand StaticCloseCommand = new RoutedCommand();

        #region CRUDView
        private CRUDView<Product> m_CRUDView = null;
        public CRUDView<Product> CRUDView
        {
            get
            {
                if (m_CRUDView == null)
                {
                    var wcfServiceController = new WCFServiceController<Product>(ConfigurationManager.AppSettings["IPAddress"], ConfigurationManager.AppSettings["TCPTLSPort"], "/secure/adapter/product", "product", true, true);
                    m_CRUDView = new CRUDView<Product>(wcfServiceController, ControllerType.WCFServiceController, new ProductViewModel());
                }
                return m_CRUDView;
            }
        }
        #endregion

        public CRUDViewListWindow()
        {
            InitializeComponent();

            CRUDView.CRUDViewModel.ViewInput = new ViewInput { keyword = "", page = 1, size = 10 };
            CRUDView.OnViewModel += CRUDView_OnViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Sets CRUDView ViewModel
            Dispatcher.BeginInvoke(new Action(() => {
                this.DataContext = CRUDView.CRUDViewModel;
            }));
        }

        /// <summary>
        /// Processes WPF view with content, list and error models.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="eventArgs"></param>
        private void CRUDView_OnViewModel(object viewModel, EventArgs eventArgs)
        {
            CRUDView.CRUDViewModel.SetViewStatus("Complete");
            
            CRUDView.CRUDViewModel.SetProcessing(false);
            CRUDView.CRUDViewModel.SetViewProcessing(false);
            CRUDView.CRUDViewModel.SetListProcessing(false);

            if (((MethodEventArgs)eventArgs).Exception)
            {
                if (((MethodEventArgs)eventArgs).MethodType == MethodType.MethodObjectCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.MethodObjectAsync)
                {
                    //CRUDMethod (Method, MethodObject) in both ServiceController and WCFServiceController 
                    //requires inheritance customization according to required solution.
                    CRUDView.CRUDViewModel.SetViewStatus("Total records response not applicable extend or use IWCFService.");
                }
                else
                {
                    CRUDView.CRUDViewModel.SetViewStatus("Exception error.");
                }
            }
            else
            {
                if (((MethodEventArgs)eventArgs).MethodType == MethodType.MethodSearchObjectCallBack ||
                ((MethodEventArgs)eventArgs).MethodType == MethodType.MethodSearchObjectAsync)
                {
                    if (((MethodEventArgs)eventArgs).MethodInput.Target.Equals("ListTotal", StringComparison.OrdinalIgnoreCase))
                    {
                        //Gets ListTotal response object.
                        int productsListTotal = (int)((IViewModel<Product>)viewModel).GetObject();

                        int listSize = ((ObserverObject<Product>)viewModel).ViewInput.Size == null ? 10 : ((int)((ObserverObject<Product>)viewModel).ViewInput.Size);
                        int totalLists = (productsListTotal / listSize) + ((productsListTotal % listSize) > 0 ? 1 : 0);
                        ((ProductViewModel)viewModel).TotalLists = string.Format("/{0}", totalLists);
                    }
                }
                else if (((MethodEventArgs)eventArgs).MethodType == MethodType.CreateCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.CreateAsync ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.UpdateCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.UpdateAsync ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.DeleteCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.DeleteAsync)
                {
                    var viewModelContentData = ((IViewModel<Product>)viewModel).GetContent();

                    ListProducts();
                }
                else if (((MethodEventArgs)eventArgs).MethodType == MethodType.ReadCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.ReadAsync)
                {
                    Dispatcher.BeginInvoke(new Action(() => {
                        var viewProductWindow = new Products.ViewWindow();
                        viewProductWindow.DataContext = ((IViewModel<Product>)viewModel).GetContent();
                        viewProductWindow.ShowDialog();
                    }));
                }
                else if (((MethodEventArgs)eventArgs).MethodType == MethodType.ListCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.ListAsync)
                {
                    var viewModelContentListData = ((IViewModel<Product>)viewModel).GetContentsList();
                }

                
                CRUDView.CRUDViewModel.SetErrors(null);

                Dispatcher.BeginInvoke(new Action(() => {
                    //this.DataContext = CRUDView.CRUDViewModel;
                    //this.DataContext = viewModel;
                }));
            }
        }

        #region CommandsAndHandlers
        private void CreateCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            var newProductWindow = new Products.NewWindow();
            newProductWindow.DataContext = new Product { Name = "New Product" };
            newProductWindow.ShowDialog();

            if (newProductWindow.DialogResult != null)
            {
                if ((bool)newProductWindow.DialogResult)
                {
                    CRUDView.CRUDViewModel.SetViewStatus("Creating...");
                    CRUDView.Create((Product)newProductWindow.DataContext);
                }
            }
        }
        private void CreateCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ReadCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            CRUDView.Read(eventArgs.Parameter);
        }
        private void ReadCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void UpdateCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                var editProductWindow = new Products.NewWindow();
                editProductWindow.DataContext = ProductsDataGrid.SelectedItem;
                editProductWindow.ShowDialog();

                if (editProductWindow.DialogResult != null)
                {
                    if ((bool)editProductWindow.DialogResult)
                    {
                        CRUDView.CRUDViewModel.SetViewStatus("Updating...");
                        CRUDView.Update((Product)editProductWindow.DataContext);
                    }
                }
            }
        }
        private void UpdateCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void DeleteCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Are you sure to delete selected record?", "Confirm Deletion", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    Product product = (Product)ProductsDataGrid.SelectedItem;
                    CRUDView.CRUDViewModel.SetViewStatus("Deleting...");
                    CRUDView.Delete(product);
                }
            }
        }
        private void DeleteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ListCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            ListProducts();
        }
        private void ListCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void NextCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            CRUDView.CRUDViewModel.ViewInput.Page++;
            ListProducts();
        }
        private void NextCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void PrevCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            CRUDView.CRUDViewModel.ViewInput.Page--;
            ListProducts();
        }
        private void PrevCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CloseCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            this.Close();
        }
        private void CloseCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ListProducts()
        {
            CRUDView.CRUDViewModel.SetViewStatus("Listing...");
            if (CRUDView.ControllerType == ControllerType.ServiceController)
            {
                CRUDView.MethodObject(CRUDView.CRUDViewModel.ViewInput.GetSearchInput(), "ListTotal");
            }
            else if (CRUDView.ControllerType == ControllerType.WCFServiceController)
            {
                CRUDView.MethodSearchObject(CRUDView.CRUDViewModel.ViewInput.GetSearchInput(), "ListTotal");
            }

            CRUDView.List(CRUDView.CRUDViewModel.ViewInput.GetSearchInput());
        }
        #endregion

        #region EventHandling
        private void ListNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (KeywordTextBox != null)
            {
                if (!string.IsNullOrEmpty(ListNumberTextBox.Text))
                {
                    try
                    {
                        CRUDView.CRUDViewModel.ViewInput.Page = int.Parse(ListNumberTextBox.Text);
                        ListProducts();
                    }
                    catch {
                        ((IViewModel<Product>)CRUDView.CRUDViewModel).SetViewStatus("Input Error");
                    }
                }
            }
        }

        private void ProductsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                CRUDView.CRUDViewModel.SetViewStatus("Reading...");
                CRUDView.Read(((Product)ProductsDataGrid.SelectedItem).UID.ToString());
            }
        }
        #endregion
    }
}
