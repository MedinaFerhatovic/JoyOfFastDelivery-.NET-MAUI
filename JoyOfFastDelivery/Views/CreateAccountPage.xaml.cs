using JoyOfFastDelivery.Models;
using JoyOfFastDelivery.Services;

namespace JoyOfFastDelivery.Views
{
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();
        }

        private async void CreateAccount_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string name = NameEntry.Text;
            string password = PasswordEntry.Text;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
            {
                var newUser = new User
                {
                    Email = email,
                    Name = name,
                    Password = password
                };

                var databaseService = new DatabaseService();
                await databaseService.AddUserAsync(newUser);

                await DisplayAlert("Poruka", "Uspješno kreiran profil", "OK");

                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Greška", "Molimo vas da popunite sva polja.", "OK");
            }
        }
    }
}
