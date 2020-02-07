using Safe.PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void ContactButton_Clicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(new Uri("mailto:gulveprashant@gmail.com"));
        }

        private async void deleteAllButton_Clicked(object sender, EventArgs e)
        {
            bool userConfirmation = await DisplayAlert("Delete All !", "This action is irreversible. Want to proceed ?", "Yes", "No");
            
            if(userConfirmation)
            {
                bool isOperationSuccessful = await Main.Instance.DeleteAll();

                if(isOperationSuccessful)
                {
                    await DisplayAlert("Success", "All data has been deleted !", "Ok");
                }
                else
                {
                    await DisplayAlert("Failure", "There was some problem deleting your data !", "Ok");
                }
            }
        }
    }
}