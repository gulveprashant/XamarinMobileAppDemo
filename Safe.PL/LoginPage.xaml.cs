using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string userName = userNameEntry.Text;
            string password = passwordEntry.Text;

            bool isUserNameEmpty = String.IsNullOrEmpty(userName);
            bool isPasswordEmpty = String.IsNullOrEmpty(password);

            if(isUserNameEmpty || isPasswordEmpty)
            {
                loginStatusLabel.Text = "Enter Valid Username / Password !";
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
        }
    }
}