using Safe.BL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Safe.BL.Entities
{
    public class Credential : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CredentialTypes _CredentialType;

        private string _Title;

        private string _Password;

        private DateTime _LastModifiedTime;

        public DateTime LastModifiedTime
        {
            get { return _LastModifiedTime; }
            set
            {
                _LastModifiedTime = value;
                NotifyPropertyChanged("LastModifiedTime");
            }
        }

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                NotifyPropertyChanged("Password");
            }
        }


        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                NotifyPropertyChanged("Title");
            }
        }



        public CredentialTypes CredentialType
        {
            get { return _CredentialType; }
            set
            {
                _CredentialType = value;
                NotifyPropertyChanged("CredentialType");
            }
        }
               

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
