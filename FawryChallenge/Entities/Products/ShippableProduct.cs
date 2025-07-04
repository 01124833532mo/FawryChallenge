using FawryChallenge.Abstractions;

namespace FawryChallenge.Entities.Products
{
    // ShippableProduct class inherits from Product and implements IShippable interface
    public class ShippableProduct : Product, IShippable
    {
        public double Weight { get; } // in kg

        public ShippableProduct(string name, decimal price, int quantity, double weight)
            : base(name, price, quantity)
        {
            Weight = weight;
        }
    }
}
