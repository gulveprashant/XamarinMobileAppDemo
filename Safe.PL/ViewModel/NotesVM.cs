using Safe.BL;
using Safe.BL.Entities;
using Safe.PL.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Safe.PL.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DeleteNoteCommand _DeleteNoteCmd;

        private EditNoteCommand _EditNoteCmd;

        private ObservableCollection<Note> _Notes;

        public NotesVM()
        {
            _Notes = Main.Instance.Notes;
            _DeleteNoteCmd = new DeleteNoteCommand();
            _EditNoteCmd = new EditNoteCommand();
        }

        public ObservableCollection<Note> Notes
        {
            get { return _Notes; }
            set
            {
                _Notes = value;
                Notify("Notes");
            }
        }


        public DeleteNoteCommand DeleteNoteCmd
        {
            get { return _DeleteNoteCmd; }
            set { _DeleteNoteCmd = value; }
        }

        public EditNoteCommand EditNoteCmd
        {
            get { return _EditNoteCmd; }
            set { _EditNoteCmd = value; }
        }

        void Notify(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
