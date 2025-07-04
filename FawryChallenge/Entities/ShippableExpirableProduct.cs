using FawryChallenge.Abstractions;

namespace FawryChallenge.Entities
{
    // ShippableExpirableProduct class inherits from Product and implements both IShippable and IExpirable interfaces
    // This class represents a product that can be shipped and has an expiration date.
    public class ShippableExpirableProduct : Product, IShippable, IExpirable
    {
        public double Weight { get; }
        public DateTime ExpiryDate { get; }

        public bool IsExpired => DateTime.Now > ExpiryDate;

        public ShippableExpirableProduct(string name, decimal price, int quantity, double weight, DateTime expiryDate)
            : base(name, price, quantity)
        {
            Weight = weight;
            ExpiryDate = expiryDate;
        }

        public override bool IsAvailable(int neededrequested)
        {
            return base.IsAvailable(neededrequested) && !IsExpired;
        }
    }
}
