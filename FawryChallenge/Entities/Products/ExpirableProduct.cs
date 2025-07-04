using FawryChallenge.Abstractions;

namespace FawryChallenge.Entities.Products
{
    // EcpirableProduct class inherits from Product and implements IExpirable interface
    public class ExpirableProduct : Product, IExpirable
    {
        public DateTime ExpiryDate { get; }

        public bool IsExpired => DateTime.Now > ExpiryDate;

        public ExpirableProduct(string name, decimal price, int quantity, DateTime expiryDate)
            : base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
        }

        public override bool IsAvailable(int neededrequested)
        {
            return base.IsAvailable(neededrequested) && !IsExpired;
        }
    }
}
