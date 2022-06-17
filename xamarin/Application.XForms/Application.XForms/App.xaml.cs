using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Application.XForms.Services;
using Application.XForms.Views;

namespace Application.XForms
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
