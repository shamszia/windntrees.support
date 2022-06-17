using Application.XForms.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindnTrees.ICRUDS.Standard;
using WindnTrees.ICRUDS.Standard.Model;
using Xamarin.Forms;
using Application.XForms.Views;
using Xamarin.Essentials;

namespace Application.XForms.ViewModels
{
    /// <summary>
    /// Category observer object is CRUDL ready MVVM view model. By default CategoryViewModel support CRUDL methods via commands that include ContentModel and ContentsListModel data members and can be extended according to requirements.
    /// </summary>
    public class CategoryViewModel : ObserverObject<Category>
    {
        /// <summary>
        /// Initialize commands with default actions. CRUDView will use following commands on form view (page) for integrating view logic. Commands and actions are pre-defined.
        /// </summary>
        public CategoryViewModel()
        {
            CreateCommand = new Command(CreateCommandAction);
            ReadCommand = new Command(ReadCommandAction);
            UpdateCommand = new Command(UpdateCommandAction);
            DeleteCommand = new Command(DeleteCommandAction);
            ListCommand = new Command(ListCommandAction);
        }
    }
}
