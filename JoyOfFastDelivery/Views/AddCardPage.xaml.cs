
namespace JoyOfFastDelivery.Views
{
    public partial class AddCardPage : ContentPage
    {
        private PaymentPage _paymentPage;

        public AddCardPage(PaymentPage paymentPage)
        {
            InitializeComponent();
            _paymentPage = paymentPage;
        }

        private async void SaveCard_Clicked(object sender, EventArgs e)
        {
            string cardNumber = cardNumberEntry.Text;


            _paymentPage?.UpdateCardList(cardNumber);

            await Navigation.PopAsync();
        }
    }
}
