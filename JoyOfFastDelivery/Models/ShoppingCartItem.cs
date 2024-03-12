namespace JoyOfFastDelivery.Models
{
    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCart
    {
        private static readonly Lazy<ShoppingCart> lazy = new Lazy<ShoppingCart>(() => new ShoppingCart());

        public static ShoppingCart Instance => lazy.Value;

        public List<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();

        private ShoppingCart() { }

        public void AddToCart(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(item => item.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new ShoppingCartItem { Product = product, Quantity = quantity });
            }
        }

        // Add other methods like RemoveFromCart, ClearCart, etc. based on your requirements.
    }
}
