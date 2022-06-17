using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Application.XForms.Models;
using Application.XForms.Views;
using Application.XForms.ViewModels;
using WindnTrees.ICRUDS.Standard;
using WindnTrees.ICRUDS.Standard.Views;
using WindnTrees.ICRUDS.Standard.Processor;
using WindnTrees.ICRUDS.Standard.Controller;
using WindnTrees.ICRUDS.Standard.Model;
using System.Windows.Input;
using Android.Widget;

namespace Application.XForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        #region CRUDView
        /// <summary>
        /// m_CRUDView, Category CRUDView data member.
        /// </summary>
        CRUDView<Category> m_CRUDView = null;
        /// <summary>
        /// CRUDView, property reference object.
        /// </summary>
        public CRUDView<Category> CRUDView
        {
            get
            {
                if (m_CRUDView == null)
                {
                    //Initialize CRUDView with protocol, ip, port, service name, service title, security status, controller type and page view model.
                    m_CRUDView = new CRUDView<Category>("http", "10.0.0.10", "80", "category", "category", false, ControllerType.HttpClientController, new CategoryViewModel());
                    m_CRUDView.OnViewModel += M_CRUDView_OnViewModel;
                    m_CRUDView.OnExceptionObject += M_CRUDView_OnExceptionObject;
                    m_CRUDView.OnMessage += M_CRUDView_OnMessage;
                }
                return m_CRUDView;
            }
        }

        /// <summary>
        /// OnViewModel, event handler.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="eventArgs"></param>
        private void M_CRUDView_OnViewModel(object viewModel, EventArgs eventArgs)
        {
            //Present view model object notified as a result of Create, Read, Update, Delete and List operations. 
            var categoryViewModel = (CategoryViewModel)viewModel;
            categoryViewModel.ListProcessing = false;
            categoryViewModel.ViewProcessing = false;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                BindingContext = categoryViewModel;
            });
        }

        /// <summary>
        /// OnExceptionObject, event handler.
        /// </summary>
        /// <param name="contentObject"></param>
        /// <param name="eventArgs"></param>
        private void M_CRUDView_OnExceptionObject(object contentObject, WindnTrees.ICRUDS.Standard.MethodEventArgs eventArgs)
        {
            //Display or process exceptions as a result of CRUDL operations.
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Toast.MakeText(Android.App.Application.Context, eventArgs.ExceptionMessage, ToastLength.Short).Show();
            });
        }

        /// <summary>
        /// OnMessage, event handler.
        /// </summary>
        /// <param name="parameter"></param>
        private void M_CRUDView_OnMessage(object parameter)
        {
            //Display or process log messages reported as a result of CRUDL operations.
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var message = ((ActionMessage)parameter).Message;
                Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
            });
        }
        #endregion

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = CRUDView.CRUDViewModel;
            SubscribeViewModelCommandEvents();

            //Response types are required for CRUDMethod remote target methods. There is no need for defining ResponseTypes for CRUDL calls. 
            //Following response type handles list response invoked by CRUDMethod "list". You may add other response types with different methods.
            CRUDView.ResponseTypes.Add(new ResponseType { TargetMethod = "list", IsListResponse = true });
            //CRUDView.ResponseTypes.Add(new ResponseType { TargetMethod = "MyList", IsListResponse = true });
        }

        /// <summary>
        /// Subscribe form based message center events for handling.
        /// </summary>
        private void SubscribeViewModelCommandEvents()
        {
            MessagingCenter.Subscribe<NewItemPage, Category>(this, "Category.CreateItem", (sender, categoryArg) => {

                CRUDView.CRUDViewModel.ContentModel = categoryArg;
                //following command creates new ContentModel in database using CRUD2CRUD http service.
                CRUDView.CRUDViewModel.GetCreateCommand().Execute(null);
                //CRUDView.CRUDViewModel.GetCreateCommand().Execute("CreateCRUD");
                //CRUDView.CRUDViewModel.GetCreateCommand().Execute("Create:CreateCRUD");
            });

            MessagingCenter.Subscribe<ItemDetailPage, Category>(this, "Category.ReadItem", (sender, categoryArg) => {

                CRUDView.CRUDViewModel.ViewInput = new ViewInput { key = categoryArg.Uid.ToString() };
                //following command read data from CRUD2CRUD http service and updates ContentModel.
                CRUDView.CRUDViewModel.GetReadCommand().Execute(null);
                //CRUDView.CRUDViewModel.GetReadCommand().Execute("ReadCRUD");
                //CRUDView.CRUDViewModel.GetReadCommand().Execute("Read:ReadCRUD");
            });

            MessagingCenter.Subscribe<EditItemPage, Category>(this, "Category.UpdateItem", (sender, categoryArg) => {

                CRUDView.CRUDViewModel.ContentModel = categoryArg;
                //following command updates ContentModel using CRUD2CRUD http service API.
                CRUDView.CRUDViewModel.GetUpdateCommand().Execute(null);
                //CRUDView.CRUDViewModel.GetUpdateCommand().Execute("UpdateCRUD");
                //CRUDView.CRUDViewModel.GetUpdateCommand().Execute("Update:UpdateCRUD");
            });
        }

        /// <summary>
        /// OnItemSelected, invoked when a list item is selected and choose between view, edit and delete actions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var category = (Category)layout.BindingContext;
            //CRUDViewModel.ContentModel will be available to following action methods for view, edit and deletion.
            CRUDView.CRUDViewModel.ContentModel = category;

            string actionResult = await DisplayActionSheet("Choose Action", "Cancel", null, new string[] { "read", "view", "edit", "delete" });
            if (!string.IsNullOrEmpty(actionResult))
            {
                if (actionResult.Equals("view"))
                {
                    await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage((CategoryViewModel)CRUDView.CRUDViewModel)));
                }
                else if (actionResult.Equals("edit"))
                {
                    await Navigation.PushModalAsync(new NavigationPage(new EditItemPage((CategoryViewModel)CRUDView.CRUDViewModel)));
                }
                else if (actionResult.Equals("read"))
                {
                    CRUDView.CRUDViewModel.ViewInput = new ViewInput { key = ((Guid)((Xamarin.Forms.TappedEventArgs)args).Parameter).ToString() };

                    CRUDView.CRUDViewModel.GetReadCommand().Execute(null);
                    //CRUDView.CRUDViewModel.GetReadCommand().Execute("ReadCRUD");
                    //CRUDView.CRUDViewModel.GetReadCommand().Execute("Read:ReadCRUD");
                }
                else if (actionResult.Equals("delete"))
                {
                    CRUDView.CRUDViewModel.GetDeleteCommand().Execute(null);
                    //CRUDView.CRUDViewModel.GetDeleteCommand().Execute("DeleteCRUD");
                    //CRUDView.CRUDViewModel.GetDeleteCommand().Execute("Delete:DeleteCRUD");
                }
            }
        }

        /// <summary>
        /// AddItem_Clicked, display new category modal form for inputing data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            CRUDView.CRUDViewModel.ViewProcessing = true;
            CRUDView.CRUDViewModel.ContentModel = new Category { Uid = Guid.NewGuid(), Title = "Create 0", Description = "Description 0" };            
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage((CategoryViewModel)CRUDView.CRUDViewModel)));
        }

        /// <summary>
        /// ListItem_Clicked, loads category list items with data from CRUDViewModel.SearchInput.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ListItem_Clicked(object sender, EventArgs e)
        {
            CRUDView.CRUDViewModel.ListProcessing = true;
            CRUDView.List(CRUDView.CRUDViewModel.ViewInput.GetSearchInput());
            //CRUDView.MethodObject(CRUDView.CRUDViewModel.ViewInput.GetSearchInput(), "ListCRUD");
            //CRUDView.MethodObject(CRUDView.CRUDViewModel.ViewInput.GetSearchInput(), "List:ListCRUD");
        }

        /// <summary>
        /// ReloadItem_Clicked, loads category list items using MethodObject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ReloadItem_Clicked(object sender, EventArgs e)
        {   
            CRUDView.CRUDViewModel.ListProcessing = true;
            CRUDView.MethodObject(CRUDView.CRUDViewModel.ViewInput.GetSearchInput(), "List");
            //CRUDView.MethodObject(CRUDView.CRUDViewModel.ViewInput.GetSearchInput(), "ListCRUD");
            //CRUDView.MethodObject(CRUDView.CRUDViewModel.ViewInput.GetSearchInput(), "List:ListCRUD");
        }

        /// <summary>
        /// CRUDMethod_Clicked, read data using CRUDMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CRUDMethod_Clicked(object sender, EventArgs e)
        {
            CRUDView.Method("EmptyCRUD");
            //CRUDView.Method("Read:EmptyCRUD");
        }
    }
}