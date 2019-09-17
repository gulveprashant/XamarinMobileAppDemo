using Safe.BL;
using Safe.BL.Entities;
using Safe.PL.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Safe.PL.ViewModel
{
    public class CredentialsVM
    {
        private DeleteCredentialCommand _DeleteCredentialCmd;

        private EditCredentialCommand _EditCredentialCmd;

        private ObservableCollection<Credential> _Credentials;

        public CredentialsVM()
        {
            _Credentials = Main.Instance.Credentials;
            _DeleteCredentialCmd = new DeleteCredentialCommand();
            _EditCredentialCmd = new EditCredentialCommand();
        }

        public ObservableCollection<Credential> Credentials
        {
            get { return _Credentials; }
            set { _Credentials = value; }
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

    }
}
