using JoyOfFastDelivery.Models;

namespace JoyOfFastDelivery.Views;

public partial class MenuPage : ContentPage
{
     public List<Product> MenuFiltrado { get; set; }
     public List<Category> Categories { get; set; }
     public MenuPage()
     {
          InitializeComponent();
          LoadData();


          BindingContext = this;
     }

     private void LoadData()
     {
          Categories = new List<Category>()
          {
               new Category
               {
                    Id = 1,
                    Name = "Predjela",
                    Image = "cat_starters.jpg",
                    Color = "#a393bf"
               },
               new Category
               {
                    Id = 2,
                    Name = "Pite",
                    Image = "pite.jpg",
                    Color = "#ef7b45"
               },
               new Category
               {
                    Id = 3,
                    Name = "Cevapi",
                    Image = "cevapi.jpg",
                    Color = "#42443e"
               },
               new Category
               {
                    Id = 4,
                    Name = "Salate",
                    Image = "salatice.jpg",
                    Color = "#ed474a"
               },
               new Category
               {
                    Id = 5,
                    Name = "Piæa",
                    Image = "sokici.jpg",
                    Color = "#cfd11a"
               },
               new Category
               {
                    Id = 6,
                    Name = "Deserti",
                    Image = "kolacici.jpg",
                    Color = "#e6f8b2"
               },
          };

          MenuFiltrado = new List<Product>
          {
                new Product { Id = 1, Name = "Pita od krompira", Image = "pite.jpg", Description = "Pita u kojoj se nalazi krompir.", Price = 20.00},
                new Product { Id = 2, Name = "5 cevapa", Image = "cevapi.jpg", Description = "Vruca lepina, 5 komada cevapa, luk i kajmak.", Price = 5},
                new Product { Id = 3, Name = "Palaèinke", Image = "pancakes.jpg", Description = "Ukusni palaèinci, napravljeni s ljubavlju i sastojcima.", Price = 10.00 },
                new Product { Id = 4, Name = "Vafli", Image = "waffles.jpg", Description = "Topli i pahuljasti vafli preliveni vašim izborom voæa, šlaga ili javorovog sirupa.", Price = 11 },
                new Product { Id = 5, Name = "Tulumbe", Image = "kolacici.jpg", Description = "Bogata i aromatièna tulumba savršena za svako doba dana.", Price = 5 },
                new Product { Id = 6, Name = "Kolaè", Image = "cake.jpg", Description = "Ukusni kolaè napravljen od nule s najsvježijim sastojcima.", Price = 7.5 },
                new Product { Id = 7, Name = "Hamburger", Image = "hamburger.jpg", Description = "Uživajte u ukusnom hamburgeru napravljenom od svježeg mljevenog mesa i prelivenog vašim odabirom dodataka.", Price = 20 },
                new Product { Id = 8, Name = "Gazirano piæe", Image = "sokici.jpg", Description = "Popijte! Naše ukusno gazirano piæe savršeno je za gasenje žeði.", Price = 3 },
                new Product { Id = 9, Name = "Salata", Image = "salad.jpg", Description = "Klasièna Cezarova salata s nasjeckanim Romaine zeljem i krušnim mrvicama, prelivena našim domaæim preljevom od Cezara.", Price = 13 }
                 

          };

     }

    private void Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
          Navigation.PushAsync(new ProductPage());
    }

     private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
     {
          await Navigation.PushAsync(new OrderDetailPage());
     }
}