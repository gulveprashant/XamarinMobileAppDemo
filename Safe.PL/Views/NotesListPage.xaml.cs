using Safe.BL;
using Safe.BL.Entities;
using Safe.PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesListPage : ContentPage
    {
        private NotesVM _ViewModel;
        public NotesListPage()
        {
            InitializeComponent();

            _ViewModel = new NotesVM();
            this.BindingContext = _ViewModel;
        }


        private void AddNoteButton_Clicked(object sender, EventArgs e)
        {
            Note note = new Note();
            Navigation.PushAsync(new NewNoteFormPage(note, false));
        }

        private void ListItem_Tapped(object sender, EventArgs e)
        {
            TextCell cell = sender as TextCell;
            if (cell != null)
            {
                Note note = cell.BindingContext as Note;
                if (note != null)
                {
                    NewNoteFormPage viewNotePage = new NewNoteFormPage(note, true);
                    viewNotePage.ToolbarItems.Clear();
                    viewNotePage.lblPageHeading.IsVisible = false;
                    Navigation.PushAsync(viewNotePage);
                }
            }
        }

        private void btnSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = sender as SearchBar;

            String searchKeyWord = searchBar.Text.ToLower();

            if (searchKeyWord.Length != 0)
            {
                _ViewModel.Notes = new ObservableCollection<Note>(_ViewModel.Notes.Where(n1 => n1.NoteText.ToLower().Contains(searchKeyWord)
            || n1.Title.ToLower().Contains(searchKeyWord)).ToList());
            }
            else
            {
                _ViewModel.Notes = Main.Instance.Notes;
            }
        }

        private void sortByTitleBtn_Clicked(object sender, EventArgs e)
        {
            Main.Instance.SortNotes("Title");

            _ViewModel.Notes = Main.Instance.Notes;
        }

        private void sortByDateModifiedBtn_Clicked(object sender, EventArgs e)
        {
            Main.Instance.SortNotes("DateModified");

            _ViewModel.Notes = Main.Instance.Notes;
        }
    }
}