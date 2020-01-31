using Safe.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safe.PL.ViewModel.Commands
{
    public class AddCredentialCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Credential credential = new Credential();
            
            Application.Current.MainPage.Navigation.PushAsync(new NewCredentialFormPage(credential, false));


        }
    }
}
