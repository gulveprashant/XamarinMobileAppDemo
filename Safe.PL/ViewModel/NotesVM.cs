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
            set { _Notes = value; }
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
    }
}
