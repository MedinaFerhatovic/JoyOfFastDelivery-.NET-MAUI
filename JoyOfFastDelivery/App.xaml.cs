using Acr.UserDialogs;
using JoyOfFastDelivery.Views;
using JoyOfFastDelivery.Services;
using JoyOfFastDelivery.ViewModels;

namespace JoyOfFastDelivery;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new HomePage()); // Ovdje postavljate svoju početnu stranicu
    }

    protected override async void OnResume()
    {
        // Inicijalizirajte bazu podataka pri pokretanju aplikacije ili nakon pauze
        var databaseService = new DatabaseService();
        await databaseService.InitializeAsync();

    }
}

