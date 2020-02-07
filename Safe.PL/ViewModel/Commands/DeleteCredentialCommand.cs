using Safe.BL;
using Safe.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Safe.PL.ViewModel.Commands
{
    public class DeleteCredentialCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Credential credential = parameter as Credential;

            bool userConfirmation = await App.Current.MainPage.DisplayAlert("Delete Credential !", "Are you sure ?", "Yes", "No");

            if (userConfirmation)
            {
                await Main.Instance.DeleteCredential(credential);
            }
        }
    }
}
