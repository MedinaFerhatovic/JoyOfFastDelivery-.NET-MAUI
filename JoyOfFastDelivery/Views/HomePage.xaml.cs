using JoyOfFastDelivery.ViewModels;
namespace JoyOfFastDelivery.Views;


[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
    }

	 private void Login_Clicked(object sender, EventArgs e)
	 {
		  Navigation.PushAsync(new StoresPage());

	 }

	 private async void CreateAccount_Clicked(object sender, EventArgs e)
	 {
		  await Navigation.PushAsync(new CreateAccountPage());
	 }
}