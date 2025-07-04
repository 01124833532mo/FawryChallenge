using FawryChallenge.Entities;
using FawryChallenge.Entities.Products;
using FawryChallenge.Service.Implementation;

namespace FawryChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create products
            var cheese = new ShippableExpirableProduct("Cheese", 100, 10, 0.4, DateTime.Now.AddDays(5));
            var biscuits = new ShippableExpirableProduct("Biscuits", 150, 5, 0.7, DateTime.Now.AddDays(10));
            var tv = new ShippableProduct("TV", 2000, 3, 15.5);
            var mobile = new NonExpirableProduct("Mobile", 800, 8);
            var scratchCard = new NonExpirableProduct("Mobile Scratch Card", 10, 100);

            // Create customer
            var customer = new Customer("Mohamed Hamdy Mahmoud", 5000);

            // Create services
            var shippingService = new ShippingService();
            var checkoutService = new CheckoutService(shippingService);

            // Test case 1: Normal checkout with shippable items

            var cart1 = new Cart();
            cart1.Add(cheese, 2);
            cart1.Add(biscuits, 1);
            cart1.Add(scratchCard, 1);
            checkoutService.Checkout(customer, cart1);



        }
    }
}
