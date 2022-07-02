using SpectrumTestApp.Services;
using SpectrumTestApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumTestApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new SplashView();
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
