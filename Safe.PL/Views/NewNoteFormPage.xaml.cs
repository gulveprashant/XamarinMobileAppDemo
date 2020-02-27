using Safe.BL.Entities;
using Safe.PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewNoteFormPage : ContentPage
    {
        private bool _IsEditNotePage;
        private Note _Note;

        public NewNoteFormPage(Note note, bool isEditPage)
        {
            _IsEditNotePage = isEditPage;
            _Note = note;

            InitializeComponent();

            this.BindingContext = _Note;
        }

        private async void SaveNoteButton_Clicked(object sender, EventArgs e)
        {
            bool isValid = true;
            Note note = this.BindingContext as Note;

            if (isValid)
            {
                if (_IsEditNotePage)
                {
                    await Main.Instance.UpdateNote(note);
                }
                else
                {
                    await Main.Instance.AddNote(note);
                }

                await DisplayAlert("Success", "Record added successfully", "Ok");

                await Navigation.PopAsync();
            }
        }

    }
}