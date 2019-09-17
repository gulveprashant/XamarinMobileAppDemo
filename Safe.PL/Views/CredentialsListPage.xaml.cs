using Safe.BL;
using Safe.BL.Entities;
using Safe.PL.ViewModel;
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
        private CredentialsVM _ViewModel;

        public CredentialsListPage()
        {
            InitializeComponent();

            _ViewModel = new CredentialsVM();

            this.BindingContext = _ViewModel;
        }

        private void CredentialAddButton_Clicked(object sender, EventArgs e)
        {
            Credential credential = new Credential();

            Navigation.PushAsync(new NewCredentialFormPage(credential, false));
        }
    }
}