using Safe.BL;
using Safe.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewNoteFormPage : ContentPage
    {
        public NewNoteFormPage()
        {
            InitializeComponent();

            this.BindingContext = new Note();
        }

        private async void SaveNoteButton_Clicked(object sender, EventArgs e)
        {
            bool isValid = true;
            Note note = this.BindingContext as Note;

            if (isValid)
            {
                await Main.Instance.AddNote(note);

                await DisplayAlert("Success", "Record added successfully", "Ok");

                await Navigation.PopAsync();
            }
        }
    }
}