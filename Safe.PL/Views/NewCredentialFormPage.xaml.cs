﻿using Safe.BL.Entities;
using Safe.PL.ViewModel;
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
        private bool _IsEditCredentialPage;
        public Credential _Credential;

        public NewCredentialFormPage(Credential cred, bool isEditPage)
        {
            _Credential = cred;
            _IsEditCredentialPage = isEditPage;

            InitializeComponent();
            
            this.BindingContext = _Credential;
        }

        private async void SaveCredentialButton_Clicked(object sender, EventArgs e)
        {
            bool isValid = true;
            Credential credential = this.BindingContext as Credential;

            if (isValid)
            {
                if(_IsEditCredentialPage)
                {
                    await Main.Instance.UpdateCredential(credential);
                }
                else
                {
                    await Main.Instance.AddCredential(credential);
                }
                

                await DisplayAlert("Success", "Record added successfully", "Ok");

                await Navigation.PopAsync();
            }
        }

        private void ContentPage_BindingContextChanged(object sender, EventArgs e)
        {
            Credential cred = this.BindingContext as Credential;
        }
    }
}