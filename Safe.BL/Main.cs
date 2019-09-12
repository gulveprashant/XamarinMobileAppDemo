using Safe.BL.Entities;
using Safe.BL.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Safe.BL
{
    public class Main:INotifyPropertyChanged
    {
        private static Main _Instance;

        private List<Note> _Notes;

        private List<Credential> _Credentials;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Credential> Credentials
        {
            get { return _Credentials; }
            set { _Credentials = value; }
        }

        public List<Note> Notes
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
            Credentials = new List<Credential>();
            Notes = new List<Note>();
           
        }

        public async void Init()
        {
            List<Credential> credentials = await DatabaseManager.Instance.GetCredentials();

            if(credentials != null)
            {
                Credentials = credentials;
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

        void Notify(String propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
