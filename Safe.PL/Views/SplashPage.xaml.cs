using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //await this.imgSplash.ScaleTo(1, 2000);
            await this.imgSplash.ScaleTo(1, 2);
            await this.imgSplash.ScaleTo(0.01, 1500, Easing.SpringIn);

            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}