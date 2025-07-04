using FawryChallenge.Abstractions;
using FawryChallenge.Entities;
using FawryChallenge.Service.Abstraction;

namespace FawryChallenge.Service.Implementation
{
    public class CheckoutService
    {
        private readonly IShippingService _shippingService;
        private const decimal ShippingFeePerKg = 20m;

        public CheckoutService(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public void Checkout(Customer customer, Cart cart)
        {
            // Validate cart
            if (!cart.Items.Any())
                throw new InvalidOperationException("Cannot checkout with empty cart");

            // Check product availability
            foreach (var item in cart.Items)
            {
                if (!item.Product.IsAvailable(item.Quantity))
                {
                    string reason = item.Product is IExpirable expirable && expirable.IsExpired
                        ? "expired"
                        : "out of stock";
                    throw new InvalidOperationException($"Product {item.Product.Name} is {reason}");
                }
            }

            // Calculate costs
            decimal subtotal = cart.CalculateSubtotal();
            decimal shippingFee = CalculateShippingFee(cart);
            decimal totalAmount = subtotal + shippingFee;

            // Check customer balance
            if (customer.Balance < totalAmount)
                throw new InvalidOperationException("Insufficient customer balance");

            // Process payment
            customer.DeductBalance(totalAmount);

            // Update inventory
            foreach (var item in cart.Items)
            {
                item.Product.ReduceQuantity(item.Quantity);
            }

            // Ship items
            var shippableItems = cart.GetShippableItems();
            if (shippableItems.Any())
            {
                _shippingService.ShipItems(shippableItems);
            }

            // Print receipt
            PrintReceipt(cart, subtotal, shippingFee, totalAmount, customer.Balance);
        }

        private decimal CalculateShippingFee(Cart cart)
        {
            var shippableItems = cart.GetShippableItems();
            if (!shippableItems.Any()) return 0;

            double totalWeight = shippableItems.Sum(i => i.Weight);
            return (decimal)totalWeight * ShippingFeePerKg;
        }

        private void PrintReceipt(Cart cart, decimal subtotal, decimal shippingFee, decimal totalAmount, decimal customerBalance)
        {
            Console.WriteLine("** Checkout receipt **");
            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.Subtotal}");
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal {subtotal}");
            Console.WriteLine("-------------------");

            Console.WriteLine($"Shipping {shippingFee}");
            Console.WriteLine("-------------------");

            Console.WriteLine($"Amount {totalAmount}");
            Console.WriteLine("-------------------");

            Console.WriteLine($"Remaining balance {customerBalance}");
        }
    }
}
