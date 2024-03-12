using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Threading.Tasks;
using JoyOfFastDelivery.Services;
using JoyOfFastDelivery.Views;

namespace JoyOfFastDelivery.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginViewModel : BindableObject
    {
        private string email;
        private string password;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            var databaseService = new DatabaseService();
            var user = await databaseService.GetUserAsync(Email);

            if (user != null && user.Password == Password)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new StoresPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login", "Pogrešan email ili lozinka.", "OK");

                await Application.Current.MainPage.Navigation.PopAsync();
            }
        });




    }
}
