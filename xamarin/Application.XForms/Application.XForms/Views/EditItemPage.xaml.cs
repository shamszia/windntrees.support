using Application.XForms.Models;
using Application.XForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.XForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItemPage : ContentPage
    {
        /// <summary>
        /// Initializes form view with CategoryViewModel object.
        /// </summary>
        /// <param name="categoryViewModel"></param>
        public EditItemPage(CategoryViewModel categoryViewModel)
        {
            InitializeComponent();
            BindingContext = categoryViewModel;
        }

        /// <summary>
        /// Report Category.UpdateItem event with ContentModel updated from EditItemPage.xaml form view. ItemsPage handles ContentModel in OnViewModel event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Category.UpdateItem", ((CategoryViewModel) BindingContext).ContentModel);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancels EditItemPage form modal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}