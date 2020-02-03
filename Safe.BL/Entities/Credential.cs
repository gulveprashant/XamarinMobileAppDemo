using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace Safe.BL.Entities
{
    [Table("Credentials")]
    public class Credential : INotifyPropertyChanged, ICloneable
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
            _Title = String.Empty;
            _Username = string.Empty;
            _Password = string.Empty;
            _HintRemark = String.Empty;
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

        private String _HintRemark;

        public String HintRemark
        {
            get { return _HintRemark; }
            set 
            {
                _HintRemark = value;
                NotifyPropertyChanged("HintRemark");
            }
        }



        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            Credential cloneObj = new Credential();

            cloneObj.CredentialType = this.CredentialType;
            cloneObj.Id = this.Id;
            cloneObj.LastModifiedTime = this.LastModifiedTime;
            cloneObj.Username = this.Username;
            cloneObj.Password = this.Password;
            cloneObj.Title = this.Title;
            cloneObj.HintRemark = this.HintRemark;

            return cloneObj;
        }
    }
}
