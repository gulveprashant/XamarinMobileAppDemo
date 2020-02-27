using Safe.BL.Entities;
using Safe.BL.Managers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Safe.PL.ViewModel
{
    public class Main:INotifyPropertyChanged
    {
        private static Main _Instance;

        private ObservableCollection<Note> _Notes;

        private ObservableCollection<Credential> _Credentials;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Credential> Credentials
        {
            get { return _Credentials; }
            set { _Credentials = value; }
        }

        public ObservableCollection<Note> Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        public static Main Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Main();
                }
                return _Instance;
            }
        }

        private Main()
        {
            Notes = new ObservableCollection<Note>();
           
        }

        public async void Init()
        {
            List<Credential> credentials = await DatabaseManager.Instance.GetCredentials();
            List<Note> notes = await DatabaseManager.Instance.GetNotes();

            if (credentials != null)
            {
                Credentials = new ObservableCollection<Credential>(credentials);
            }

            if (notes != null)
            {
                Notes = new ObservableCollection<Note>(notes);
            }
        }

        public async Task AddCredential(Credential credential)
        {
            bool isAdded = await DatabaseManager.Instance.AddCredential(credential);

            if (isAdded)
            {
                Credentials.Add(credential);

                Notify("Credentials");
            }
        }

        public async Task AddNote(Note note)
        {
            bool isAdded = await DatabaseManager.Instance.AddNote(note);

            if (isAdded)
            {
                Notes.Add(note);

                Notify("Notes");
            }
        }

        public async Task UpdateCredential(Credential credential)
        {
            bool isUpdated = await DatabaseManager.Instance.UpdateCredential(credential);

            if (isUpdated)
            {
                Credential fromMasterList =  (from cred in Credentials where credential.Id == cred.Id select cred).FirstOrDefault();

                fromMasterList.Title = credential.Title;
                fromMasterList.Username = credential.Username;
                fromMasterList.Password = credential.Password;
                fromMasterList.HintRemark = credential.HintRemark;
                fromMasterList.LastModifiedTime = credential.LastModifiedTime;

                Notify("Credentials");
            }
        }

        public async Task UpdateNote(Note note)
        {
            bool isUpdated = await DatabaseManager.Instance.UpdateNote(note);

            if (isUpdated)
            {
                Note fromMasterList = (from n in Notes where note.Id == n.Id select n).FirstOrDefault();

                fromMasterList.Title = note.Title;
                fromMasterList.NoteText = note.NoteText;
                fromMasterList.LastModifiedTime = note.LastModifiedTime;

                Notify("Notes");
            }
        }

        public async Task DeleteCredential(Credential credential)
        {
            bool isremoved = await DatabaseManager.Instance.DeleteCredential(credential);

            if (isremoved)
            {
                Credentials.Remove(credential);

                Notify("Credentials");
            }
        }

        public async Task DeleteNote(Note note)
        {
            bool isremoved = await DatabaseManager.Instance.DeleteNote(note);

            if (isremoved)
            {
                Notes.Remove(note);

                Notify("Notes");
            }
        }

        public void SortNotes(string criteria)
        {
            switch(criteria)
            {
                case "Title":
                    {
                        var sortedList = Notes.OrderBy(note => note.Title);
                        Notes = new ObservableCollection<Note>(sortedList);
                    }
                    break;
                case "Date Modified":
                    {
                        var sortedList = Notes.OrderByDescending(note => note.LastModifiedTime);
                        Notes = new ObservableCollection<Note>(sortedList);
                    }
                    break;

            }
        }

        public void SortCredentials(string criteria)
        {
            switch (criteria)
            {
                case "Title":
                    {
                        var sortedList = Credentials.OrderBy(cred => cred.Title);
                        Credentials = new ObservableCollection<Credential>(sortedList);
                    }
                    break;
                case "Date Modified":
                    {
                        var sortedList = Credentials.OrderByDescending(cred => cred.LastModifiedTime);
                        Credentials = new ObservableCollection<Credential>(sortedList);
                    }
                    break;

            }
        }

        public async Task<bool> DeleteAll()
        {
            bool isDeleteCredSuccessful =  await DatabaseManager.Instance.DeleteAllCredential();

            if(isDeleteCredSuccessful)
            {
                Credentials.Clear();
            }

            bool isDeleteNotesSuccessful = await DatabaseManager.Instance.DeleteAllNotes();

            if (isDeleteNotesSuccessful)
            {
                Notes.Clear();
            }

            return (isDeleteCredSuccessful && isDeleteNotesSuccessful);
        }

        void Notify(String propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
