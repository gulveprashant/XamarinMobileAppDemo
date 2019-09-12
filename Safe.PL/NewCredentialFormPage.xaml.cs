using Safe.BL;
using Safe.BL.Entities;
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
    public partial class NewCredentialFormPage : ContentPage
    {
        public NewCredentialFormPage()
        {
            InitializeComponent();
            this.BindingContext = new Credential();
        }

        private async void SaveCredentialButton_Clicked(object sender, EventArgs e)
        {
            bool isValid = true;
            Credential credential = this.BindingContext as Credential;

            if (isValid)
            {
                await Main.Instance.AddCredential(credential);

                DisplayAlert("Success", "Record added successfully", "Ok");

                await Navigation.PopAsync();
            }
        }
    }
}