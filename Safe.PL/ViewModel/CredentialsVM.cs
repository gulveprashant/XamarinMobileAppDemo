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
    public class CredentialsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DeleteCredentialCommand _DeleteCredentialCmd;

        private EditCredentialCommand _EditCredentialCmd;

        private AddCredentialCommand _AddCredentialCmd;

        private ObservableCollection<Credential> _Credentials;

        public CredentialsVM()
        {
            _Credentials = Main.Instance.Credentials;
            _DeleteCredentialCmd = new DeleteCredentialCommand();
            _EditCredentialCmd = new EditCredentialCommand();
            _AddCredentialCmd = new AddCredentialCommand();
        }

        public ObservableCollection<Credential> Credentials
        {
            get { return _Credentials; }
            set 
            {
                _Credentials = value;
                Notify("Credentials");
            }
        }


        public DeleteCredentialCommand DeleteCredentialCmd
        {
            get { return _DeleteCredentialCmd; }
            set { _DeleteCredentialCmd = value; }
        }

        public EditCredentialCommand EditCredentialCmd
        {
            get { return _EditCredentialCmd; }
            set { _EditCredentialCmd = value; }
        }

        public AddCredentialCommand AddCredentialCmd
        {
            get { return _AddCredentialCmd; }
            set { _AddCredentialCmd = value; }
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
