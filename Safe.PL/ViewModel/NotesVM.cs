using Safe.BL;
using Safe.BL.Entities;
using Safe.PL.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Safe.PL.ViewModel
{
    public class NotesVM
    {
        private DeleteNoteCommand _DeleteNoteCmd;

        private ObservableCollection<Note> _Notes;

        public NotesVM()
        {
            _Notes = Main.Instance.Notes;
            _DeleteNoteCmd = new DeleteNoteCommand();
        }

        public ObservableCollection<Note> Credentials
        {
            get { return _Notes; }
            set { _Notes = value; }
        }


        public DeleteNoteCommand DeleteNoteCmd
        {
            get { return _DeleteNoteCmd; }
            set { _DeleteNoteCmd = value; }
        }
    }
}
