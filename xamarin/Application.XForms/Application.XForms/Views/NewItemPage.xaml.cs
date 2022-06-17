using System;
using System.Collections.Generic;
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
    public partial class NewItemPage : ContentPage
    {
        /// <summary>
        /// Initializes form view with CategoryViewModel object.
        /// </summary>
        /// <param name="categoryViewModel"></param>
        public NewItemPage(CategoryViewModel categoryViewModel)
        {
            InitializeComponent();
            BindingContext = categoryViewModel;
        }

        /// <summary>
        /// Reports Category.CreateItem event with ContentModel including new data from NewItemPage.xaml form view. ItemsPage handles new ContentModel in OnViewModel event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {   
            MessagingCenter.Send(this, "Category.CreateItem", ((CategoryViewModel) BindingContext).ContentModel);
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