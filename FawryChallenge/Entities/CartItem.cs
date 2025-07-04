using FawryChallenge.Entities.Products;

namespace FawryChallenge.Entities
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal Subtotal => Product.Price * Quantity;
    }
}
