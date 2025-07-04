namespace FawryChallenge.Entities
{

    // this abstract class to be an implementation for future services
    public abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        protected Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public virtual bool IsAvailable(int neededQuantity)
        {
            // must need to check if the quantity is greater than or equal to the needed quantity
            return Quantity >= neededQuantity && neededQuantity > 0;
        }

        public void ReduceQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));
            else if (quantity == 0)
                return; // No need to reduce quantity if it's zero
            else if (Quantity <= 0)
                throw new InvalidOperationException("Product is out of stock");

            else if (quantity > Quantity)
                throw new InvalidOperationException("Not enough stock available");
            // Reduce the quantity of the product

            Quantity -= quantity;
        }
    }
}
