using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Safe.BL.Entities
{
    [Table("Note")]
    public class Note : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _Id;

        private string _Title;

        private string _NoteText;

        private DateTime _LastModifiedTime;

        public Note()
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
