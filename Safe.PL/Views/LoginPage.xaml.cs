using SkiaSharp;
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
            /*
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
            */
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        private void pinEntryCtrl_PinEntryCompleted(string enteredPin)
        {
            if(String.Equals(enteredPin, "123456"))
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                Xamarin.Essentials.Vibration.Vibrate();
            }
        }

        private void pinEntryCtrl_NotifyMajorPinEvent(Controls.PinEntryControlState state)
        {
            switch (state)
            {
                case Controls.PinEntryControlState.ENTRY_IN_PROGRESS:
                    break;
                case Controls.PinEntryControlState.TOO_MANY_TRIES:
                    {
                        Xamarin.Essentials.Vibration.Vibrate();
                    }
                    break;
                case Controls.PinEntryControlState.PIN_AUTH_SUCCESS:
                case Controls.PinEntryControlState.FINGERPRINT_AUTH_SUCCESS:
                    {
                        Application.Current.MainPage = new NavigationPage(new MainPage());
                    }
                    break;
                default:
                    break;
            }
        }
    }
}