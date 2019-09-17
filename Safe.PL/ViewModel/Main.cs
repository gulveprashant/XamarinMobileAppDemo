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

            if(credentials != null)
            {
                Credentials = new ObservableCollection<Credential>(credentials);
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

        public async Task UpdateCredential(Credential credential)
        {
            bool isUpdated = await DatabaseManager.Instance.UpdateCredential(credential);

            if (isUpdated)
            {
                //Credentials.Add(credential);
                Credential fromMasterList =  (from cred in Credentials where credential.Id == cred.Id select cred).FirstOrDefault();

                fromMasterList.Title = credential.Title;
                fromMasterList.Username = credential.Username;
                fromMasterList.Password = credential.Password;

                Notify("Credentials");
            }
        }

        public async Task DeleteCredential(Credential credential)
        {
            bool isAdded = await DatabaseManager.Instance.DeleteCredential(credential);

            if (isAdded)
            {
                Credentials.Remove(credential);

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
