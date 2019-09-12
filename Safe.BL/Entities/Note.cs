using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Safe.BL.Entities
{
    public class Note : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _Title;

        private string _NoteText;

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


        public string NoteText
        {
            get { return _NoteText; }
            set
            {
                _NoteText = value;
                NotifyPropertyChanged("NoteText");
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

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
