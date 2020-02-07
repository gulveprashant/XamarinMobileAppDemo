using Safe.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Safe.PL.ViewModel.Commands
{
    public class DeleteNoteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Note note = parameter as Note;

            bool userConfirmation = await App.Current.MainPage.DisplayAlert("Delete Note !", "Are you sure ?", "Yes", "No");

            if (userConfirmation)
            {
                await Main.Instance.DeleteNote(note);
            }
        }
    }
}
