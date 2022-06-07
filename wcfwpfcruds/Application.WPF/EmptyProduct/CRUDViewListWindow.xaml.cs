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
using WindnTrees.ICRUDS;
using WindnTrees.ICRUDS.Controller;
using WindnTrees.ICRUDS.Processor;
using WindnTrees.ICRUDS.Model;
using WindnTrees.ICRUDS.Views;
using ApplicationWPF.ViewModels;
using System.ServiceModel.Security;

namespace ApplicationWPF.EmptyProduct
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

        #region EmptyCRUDView
        private EmptyCRUDView<Product> m_EmptyCRUDView = null;
        public EmptyCRUDView<Product> EmptyCRUDView
        {
            get
            {
                if (m_EmptyCRUDView == null)
                {
                    var wcfServiceController = new WCFEmptyServiceController<Product>(ConfigurationManager.AppSettings["IPAddress"], ConfigurationManager.AppSettings["TCPTLSPort"], "/secure/adapter/product/empty", "product", true, true);
                    m_EmptyCRUDView = new EmptyCRUDView<Product>(wcfServiceController, ControllerType.WCFEmptyServiceController, new ProductViewModel());
                }
                return m_EmptyCRUDView;
            }
        }
        #endregion

        public CRUDViewListWindow()
        {
            InitializeComponent();

            EmptyCRUDView.OnViewModel += EmptyCRUDView_OnViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Sets CRUDView ViewModel
            Dispatcher.BeginInvoke(new Action(() => {
                this.DataContext = EmptyCRUDView.CRUDViewModel;
            }));
        }

        /// <summary>
        /// Processes WPF view with content, list and error models.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="eventArgs"></param>
        private void EmptyCRUDView_OnViewModel(object viewModel, EventArgs eventArgs)
        {
            EmptyCRUDView.CRUDViewModel.SetViewStatus("Complete");

            EmptyCRUDView.CRUDViewModel.SetProcessing(false);
            EmptyCRUDView.CRUDViewModel.SetViewProcessing(false);
            EmptyCRUDView.CRUDViewModel.SetListProcessing(false);

            if (((MethodEventArgs)eventArgs).Exception)
            {
                if (((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyMethod ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyMethodCallBack)
                {
                    //CRUDMethod (Method, MethodObject) in both ServiceController and WCFServiceController 
                    //requires inheritance customization according to required solution.
                    EmptyCRUDView.CRUDViewModel.SetViewStatus("Total records response not applicable extend or use IWCFEmptyService.");
                }
                else
                {
                    EmptyCRUDView.CRUDViewModel.SetViewStatus("Exception error.");
                }
            }
            else
            {
                if (((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyMethod ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyMethodCallBack)
                {
                    if (((MethodEventArgs)eventArgs).MethodInput.Target.Equals("ListTotal", StringComparison.OrdinalIgnoreCase))
                    {
                        //Gets ListTotal response object.
                        int productsListTotal = (int)((IViewModel<Product>)viewModel).GetObject();

                        //int listSize = ((ObserverObject<Product>)viewModel).ViewInput.Size == null ? 10 : ((int)((ObserverObject<Product>)viewModel).ViewInput.Size);
                        //int totalLists = (productsListTotal / listSize) + ((productsListTotal % listSize) > 0 ? 1 : 0);
                        //((ProductViewModel)viewModel).TotalLists = string.Format("/{0}", totalLists);
                    }
                }
                else if (((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyCreateCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyCreateAsync ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyUpdateCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyUpdateAsync ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyDeleteCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyDeleteAsync)
                {   
                    var viewModelContentData = ((IViewModel<Product>)viewModel).GetContent();
                    ((IViewModel<Product>)viewModel).SetContentsList(new System.Collections.ObjectModel.ObservableCollection<Product> { viewModelContentData });
                }
                else if (((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyReadCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyReadAsync)
                {
                    var viewModelContentData = ((IViewModel<Product>)viewModel).GetContent();
                    ((IViewModel<Product>)viewModel).SetContentsList(new System.Collections.ObjectModel.ObservableCollection<Product> { viewModelContentData });
                }
                else if (((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyListCallBack ||
                    ((MethodEventArgs)eventArgs).MethodType == MethodType.EmptyListAsync)
                {
                    var viewModelContentListData = ((IViewModel<Product>)viewModel).GetContentsList();
                }

                EmptyCRUDView.CRUDViewModel.SetErrors(null);

                Dispatcher.BeginInvoke(new Action(() => {
                    //this.DataContext = CRUDView.CRUDViewModel;
                    //this.DataContext = viewModel;
                }));
            }
        }

        #region CommandsAndHandlers
        private void CreateCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            EmptyCRUDView.CRUDViewModel.SetViewStatus("Creating...");
            EmptyCRUDView.Create();
        }
        private void CreateCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ReadCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            EmptyCRUDView.CRUDViewModel.SetViewStatus("Reading...");
            EmptyCRUDView.Read();
        }
        private void ReadCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void UpdateCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            EmptyCRUDView.CRUDViewModel.SetViewStatus("Updating...");
            EmptyCRUDView.Update();
        }
        private void UpdateCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void DeleteCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {
            EmptyCRUDView.CRUDViewModel.SetViewStatus("Deleting...");
            EmptyCRUDView.Delete();
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
            ListProducts();
        }
        private void NextCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void PrevCommandHandler(object source, ExecutedRoutedEventArgs eventArgs)
        {   
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
            EmptyCRUDView.CRUDViewModel.SetViewStatus("Listing...");
            if (EmptyCRUDView.ControllerType == ControllerType.EmptyServiceController)
            {
                EmptyCRUDView.EmptyMethod("ListTotal");
            }
            else if (EmptyCRUDView.ControllerType == ControllerType.WCFEmptyServiceController)
            {
                EmptyCRUDView.EmptyMethod("ListTotal");
            }
            EmptyCRUDView.List();
        }
        #endregion

        #region EventHandling
        private void ListNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ProductsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                EmptyCRUDView.CRUDViewModel.SetViewStatus("Reading...");
                EmptyCRUDView.Read();
            }
        }
        #endregion
    }
}
