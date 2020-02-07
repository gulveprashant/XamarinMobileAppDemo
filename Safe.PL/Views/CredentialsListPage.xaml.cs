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
    public partial class CredentialsListPage : ContentPage
    {
        private CredentialsVM _ViewModel;

        public CredentialsListPage()
        {
            InitializeComponent();

            _ViewModel = new CredentialsVM();

            this.BindingContext = _ViewModel;
        }

        private void CredentialAddButton_Clicked(object sender, EventArgs e)
        {
            Credential credential = new Credential();

            Navigation.PushAsync(new NewCredentialFormPage(credential, false));
        }
        
        private void ListItem_Tapped(object sender, EventArgs e)
        {
            TextCell cell = sender as TextCell;
            if(cell != null)
            {
                Credential credential = cell.BindingContext as Credential;
                if (credential != null)
                {
                    NewCredentialFormPage viewCredPage = new NewCredentialFormPage(credential, true);
                    viewCredPage.ToolbarItems.Clear();
                    viewCredPage.lblPageHeading.IsVisible = false;
                    Navigation.PushAsync(viewCredPage);
                }
            }
        }

        private void btnSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = sender as SearchBar;

            String searchKeyWord = searchBar.Text.ToLower();

            if (searchKeyWord.Length != 0)
            {
                _ViewModel.Credentials = new ObservableCollection<Credential>(_ViewModel.Credentials.Where(c => c.Username.ToLower().Contains(searchKeyWord)
            || c.Title.ToLower().Contains(searchKeyWord)));
            }
            else
            {
                _ViewModel.Credentials = Main.Instance.Credentials;
            }
        }

        private void sortByTitleBtn_Clicked(object sender, EventArgs e)
        {
            Main.Instance.SortCredentials("Title");

            _ViewModel.Credentials = Main.Instance.Credentials;
        }

        private void sortByDateModifiedBtn_Clicked(object sender, EventArgs e)
        {
            Main.Instance.SortCredentials("DateModified");

            _ViewModel.Credentials = Main.Instance.Credentials;
        }
    }
}