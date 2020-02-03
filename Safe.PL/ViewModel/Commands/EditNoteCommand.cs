using Safe.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safe.PL.ViewModel.Commands
{
    public class EditNoteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Note note = parameter as Note;

            Note cloneNote = note.Clone() as Note;

            cloneNote.LastModifiedTime = DateTime.Now;

            Application.Current.MainPage.Navigation.PushAsync(new NewNoteFormPage(cloneNote, true));
        }
    }
}
