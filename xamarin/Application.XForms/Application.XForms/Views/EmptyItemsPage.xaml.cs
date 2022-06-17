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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyItemsPage : ContentPage
    {
        #region EmptyCRUDView
        /// <summary>
        /// m_EmptyCRUDView, Category EmptyCRUDView data member.
        /// </summary>
        EmptyCRUDView<Category> m_EmptyCRUDView = null;
        /// <summary>
        /// EmptyCRUDView, property reference object.
        /// </summary>
        public EmptyCRUDView<Category> EmptyCRUDView
        {
            get
            {
                if (m_EmptyCRUDView == null)
                {
                    //Initialize EmptyCRUDView with protocol, ip, port, service name (uri), service title, security status, controller type and page view model.

                    m_EmptyCRUDView = new EmptyCRUDView<Category>("http", "10.0.0.10", "80", "categoryempty", "Category Empty", false, ControllerType.HttpEmptyClientController, new CategoryViewModel());
                    m_EmptyCRUDView.OnViewModel += M_EmptyCRUDView_OnViewModel;
                    m_EmptyCRUDView.OnExceptionObject += M_EmptyCRUDView_OnExceptionObject;
                    m_EmptyCRUDView.OnMessage += M_EmptyCRUDView_OnMessage;
                }
                return m_EmptyCRUDView;
            }
        }

        /// <summary>
        /// OnViewModel, event handler.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="eventArgs"></param>
        private void M_EmptyCRUDView_OnViewModel(object viewModel, EventArgs eventArgs)
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
        private void M_EmptyCRUDView_OnExceptionObject(object contentObject, WindnTrees.ICRUDS.Standard.MethodEventArgs eventArgs)
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
        private void M_EmptyCRUDView_OnMessage(object parameter)
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
        public EmptyItemsPage()
        {
            InitializeComponent();
            BindingContext = EmptyCRUDView.CRUDViewModel;

            //Response types are required for EmptyMethod (CRUDMethod) remote target methods. There is no need for defining ResponseTypes for CRUDL calls. 
            //Following response type handles list response invoked by CRUDMethod "list". You may add other response types with different methods.
            EmptyCRUDView.ResponseTypes.Add(new ResponseType { TargetMethod = "list", IsListResponse = true });
            EmptyCRUDView.ResponseTypes.Add(new ResponseType { TargetMethod = "ListCRUD", IsListResponse = true });
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
            //CRUDViewModel.ContentModel will be available to following action methods for view.
            EmptyCRUDView.CRUDViewModel.ContentModel = category;

            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage((CategoryViewModel)EmptyCRUDView.CRUDViewModel)));
        }

        /// <summary>
        /// AddItem_Clicked, add a new item in EmptyCRUDController.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem_Clicked(object sender, EventArgs e)
        {
            EmptyCRUDView.CRUDViewModel.ViewProcessing = true;

            //Requires no crud view model
            EmptyCRUDView.Create();
            //EmptyCRUDView.EmptyMethod("create:CreateCRUD");
            //EmptyCRUDView.EmptyMethod("CreateCRUD");
        }

        /// <summary>
        /// UpdateItem_Clicked, updates an item in EmptyCRUDController.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateItem_Clicked(object sender, EventArgs e)
        {
            EmptyCRUDView.CRUDViewModel.ViewProcessing = true;

            //Requires no crud view model
            EmptyCRUDView.Update();
            //EmptyCRUDView.EmptyMethod("update:UpdateCRUD");
            //EmptyCRUDView.EmptyMethod("UpdateCRUD");
        }

        /// <summary>
        /// DeleteItem_Clicked, deletes an item in EmptyCRUDController.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItem_Clicked(object sender, EventArgs e)
        {
            EmptyCRUDView.CRUDViewModel.ViewProcessing = true;

            //Requires no crud view model
            EmptyCRUDView.Delete();
            //EmptyCRUDView.EmptyMethod("delete:DeleteCRUD");
            //EmptyCRUDView.EmptyMethod("DeleteCRUD");
        }

        /// <summary>
        /// ReadItem_Clicked, read an item in EmptyCRUDController.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadItem_Clicked(object sender, EventArgs e)
        {
            EmptyCRUDView.CRUDViewModel.ViewProcessing = true;

            //Requires no crud view model
            EmptyCRUDView.Read();
            //EmptyCRUDView.EmptyMethod("read:ReadCRUD");
            //EmptyCRUDView.EmptyMethod("ReadCRUD");
        }

        /// <summary>
        /// ListItem_Clicked, loads category list items with data from CRUDViewModel.SearchInput.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListItem_Clicked(object sender, EventArgs e)
        {
            EmptyCRUDView.CRUDViewModel.ListProcessing = true;
            EmptyCRUDView.List();
            //EmptyCRUDView.EmptyMethod("list:ListCRUD");
            //EmptyCRUDView.EmptyMethod("ListCRUD");
        }

        /// <summary>
        /// ReloadItem_Clicked, loads category list items using EmptyMethod (CRUDMethod).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadItem_Clicked(object sender, EventArgs e)
        {
            EmptyCRUDView.CRUDViewModel.ListProcessing = true;
            EmptyCRUDView.EmptyMethod("list");
            //EmptyCRUDView.EmptyMethod("list:ListCRUD");
            //EmptyCRUDView.EmptyMethod("ListCRUD");
        }
    }
}