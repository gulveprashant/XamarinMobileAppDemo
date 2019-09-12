using Safe.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CredentialsListPage : ContentPage
    {
        public CredentialsListPage()
        {
            InitializeComponent();

            Main.Instance.PropertyChanged += ListUpdatedEventHandler;
        }

        private void ListUpdatedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "Credentials":
                    {
                        credentialsListView.ItemsSource = Main.Instance.Credentials;
                        break;
                    }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

           credentialsListView.ItemsSource = Main.Instance.Credentials;
        }

        private void CredentialAddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewCredentialFormPage());
        }
    }
}