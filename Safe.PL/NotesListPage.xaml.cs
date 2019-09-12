using Safe.BL;
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
        public NotesListPage()
        {
            InitializeComponent();

            Main.Instance.PropertyChanged += ListUpdatedEventHandler;
        }

        private void ListUpdatedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Notes":
                    {
                        notesListView.ItemsSource = Main.Instance.Notes;
                        break;
                    }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            notesListView.ItemsSource = Main.Instance.Notes;
        }

        private void AddNoteButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewNoteFormPage());
        }
    }
}