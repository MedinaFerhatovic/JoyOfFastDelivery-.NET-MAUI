using JoyOfFastDelivery.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JoyOfFastDelivery.Views
{
    public partial class PaymentPage : ContentPage
    {
        public List<string> CardList { get; set; }
        private Order CurrentOrder { get; }
        private ShoppingCart ShoppingCart { get; }

        public PaymentPage(Order currentOrder, ShoppingCart shoppingCart)
        {
            InitializeComponent();
            CurrentOrder = currentOrder;
            ShoppingCart = shoppingCart;
            CardList = new List<string>(); 
            CollectionView.ItemsSource = CardList; 
        }

        private async void Pay_Clicked(object sender, EventArgs e)
        {
            paymentScreen.IsVisible = true;
            animation.IsAnimationEnabled = true;
            await Task.Delay(3000);
            await Navigation.PushAsync(new StoresPage());
        }

        public void UpdateCardList(string newCard)
        {
            CardList.Add(newCard); 
            CollectionView.ItemsSource = null;
            CollectionView.ItemsSource = CardList; 
        }

        private async void AddNewCard_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCardPage(this));
        }
    }
}
