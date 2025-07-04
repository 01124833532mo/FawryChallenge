using FawryChallenge.Abstractions;
using FawryChallenge.Entities.Products;

namespace FawryChallenge.Entities
{
    public class Cart
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        public IEnumerable<CartItem> Items => _items.AsEnumerable();

        public void Add(Product product, int quantity)
        {
            if (!product.IsAvailable(quantity))
                throw new InvalidOperationException($"Product {product.Name} is not available in the needed quantity");

            // check if the product is already in the cart
            var existingItem = _items.FirstOrDefault(i => i.Product == product);
            if (existingItem != null)
            {
                // Combine quantities if product already in cart
                if (!product.IsAvailable(existingItem.Quantity + quantity))
                    throw new InvalidOperationException($"Cannot add {quantity} more of {product.Name} to cart");
                Console.WriteLine("-------------------------------------------");

                _items.Remove(existingItem);
                _items.Add(new CartItem(product, existingItem.Quantity + quantity));
            }
            else
            {
                _items.Add(new CartItem(product, quantity));
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public decimal CalculateSubtotal()
        {
            return _items.Sum(item => item.Subtotal);
        }

        public List<IShippable> GetShippableItems()
        {
            // linq query to filter and select shippable items
            return _items
                .Where(item => item.Product is IShippable)
                .Select(item => new
                {
                    Shippable = (IShippable)item.Product,
                    item.Quantity
                })
                .SelectMany(x => Enumerable.Repeat(x.Shippable, x.Quantity))
                .ToList();
        }
    }
}
