using HPlus_App.Services;
using HPlus_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HPlus_App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
