using Safe.BL;
using Safe.BL.Entities;
using Safe.PL.ViewModel;
using System;
using System.Collections.Generic;
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
    }
}