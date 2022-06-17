using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Application.XForms.Models;
using Application.XForms.ViewModels;

namespace Application.XForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        /// <summary>
        /// Initializes form view with CategoryViewModel object.
        /// </summary>
        /// <param name="categoryViewModel"></param>
        public ItemDetailPage(CategoryViewModel categoryViewModel)
        {
            InitializeComponent();
            BindingContext = categoryViewModel;
        }

        /// <summary>
        /// Reports Category.ReadItem event with existing ContentModel and cancels modal form. Read model is reported in OnViewModel event on ItemsPage. This method demonstrats CRUDView "read" invocation and does not update form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Referesh_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Category.ReadItem", ((CategoryViewModel)BindingContext).ContentModel);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancels modal form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}