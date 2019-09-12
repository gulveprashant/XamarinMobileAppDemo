using Safe.BL;
using Safe.BL.Managers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Main.Instance.Init();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
