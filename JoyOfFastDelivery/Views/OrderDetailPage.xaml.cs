using JoyOfFastDelivery.Models;

namespace JoyOfFastDelivery.Views;

public partial class OrderDetailPage : ContentPage
{
	 public Order CurrentOrder { get; set; }
	public OrderDetailPage()
	{
		InitializeComponent();
          CurrentOrder = new Order
		  {
			   Products = new List<Product>
			   {
                   new Product { Id = 1, Name = "Pita od krompira", Image = "pite.jpg", Description = "Pita u kojoj se nalazi krompir.", Price = 20.00, Quantity=1},
                new Product { Id = 2, Name = "5 cevapa", Image = "cevapi.jpg", Description = "Vruca lepina, 5 komada cevapa, luk i kajmak.", Price = 5, Quantity=1},
               }
		  };
		  BindingContext = this;
	}

    private void Checkout_Clicked(object sender, EventArgs e)
    {
        var paymentPage = new PaymentPage(CurrentOrder, ShoppingCart.Instance);
        Navigation.PushAsync(paymentPage);
    }
}