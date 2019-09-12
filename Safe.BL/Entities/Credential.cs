﻿using Safe.BL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace Safe.BL.Entities
{
    [Table("Credentials")]
    public class Credential : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _Id;

        private String _CredentialType;

        private string _Title;

        private string _Username;
        
        private string _Password;

        private DateTime _LastModifiedTime;

        public Credential()
        {
            _LastModifiedTime = DateTime.Now;
        }

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public DateTime LastModifiedTime
        {
            get { return _LastModifiedTime; }
            set
            {
                _LastModifiedTime = value;
                NotifyPropertyChanged("LastModifiedTime");
            }
        }

        public string Username
        {
            get { return _Username; }
            set {
                _Username = value;
                NotifyPropertyChanged("Username");
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


        
        public String CredentialType
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
