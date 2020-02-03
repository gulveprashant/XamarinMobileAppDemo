using Safe.PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            credBtn.Text = String.Format("{0} credential(s) !", Main.Instance.Credentials.Count);

            notesBtn.Text = String.Format("{0} note(s) !", Main.Instance.Notes.Count);
        }

        private void notesBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotesListPage());
        }

        private void credBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CredentialsListPage());
        }
    }
}