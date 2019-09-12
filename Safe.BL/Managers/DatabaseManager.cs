using Safe.BL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Safe.BL.Managers
{
    public class DatabaseManager
    {
        private string _DatabaseURI;

        private static DatabaseManager _Instance;

        public static DatabaseManager Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DatabaseManager();
                }
                return _Instance;
            }
        }

        private DatabaseManager()
        {

        }

        public bool Connect()
        {
            return true;
        }

        public bool Disconnect()
        {
            return true;
        }

        public bool GetCredentialsAndNotes(ref ObservableCollection<Credential> credentials,
            ref ObservableCollection<Note> notes)
        {
            credentials.Clear();
            notes.Clear();

            return true;
        }
        
        public bool AddCredential(ref Credential credential)
        {
            return true;
        }

        public bool DeleteCredential(ref Credential credential)
        {
            return true;
        }

        public bool AddNote(ref Note note)
        {
            return true;
        }

        public bool DeleteNote(ref Note note)
        {
            return true;
        }

        public void DeleteDatabase()
        {

        }
    }
}
