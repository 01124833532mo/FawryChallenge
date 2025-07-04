namespace FawryChallenge.Entities
{
    public class NonExpirableProduct : Product
    {
        public NonExpirableProduct(string name, decimal price, int quantity)
            : base(name, price, quantity) { }
    }
}
