using JoyOfFastDelivery.Models;

namespace JoyOfFastDelivery.Views;

public partial class StorePage : ContentPage
{
	 public Store Store { get; set; }
     public List<Category> Categories { get; set; }
     
	public StorePage()
	{
		InitializeComponent();
          Store =
               new Store
               {
                    Id = 1,
                    Header = "header1.jpg",
                    Logo = "logo1a.jpg",
                    Name = "Naša kuæa",
                    DeliveryTime = "30 - 40 mins",
                    Minimum = 150,
                    ServiceFee = 10,
                    Rating = 4.5
               };


          Categories = new List<Category>()
          {
               new Category
               {
                    Id = 1,
                    Name = "Predjela",
                    Image = "cat_starters.jpg",
                    Color = "#813607"
               },
               new Category
               {
                    Id = 2,
                    Name = "Pite",
                    Image = "pite.jpg",
                    Color = "#813607"
               },
               new Category
               {
                    Id = 3,
                    Name = "Cevapi",
                    Image = "cevapi.jpg",
                    Color = "#813607"
               },
               new Category
               {
                    Id = 4,
                    Name = "Salate",
                    Image = "salatice.jpg",
                    Color = "#813607"
               },
               new Category
               {
                    Id = 5,
                    Name = "Piæa",
                    Image = "sokici.jpg",
                    Color = "#813607"
               },
               new Category
               {
                    Id = 6,
                    Name = "Deserti",
                    Image = "kolacici.jpg",
                    Color = "#813607"
               },
          };

          BindingContext = this;
    }

    private void Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
          Navigation.PushAsync(new MenuPage());
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
          await Navigation.PushAsync(new OrderDetailPage());
     }
}