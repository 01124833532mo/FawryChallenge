namespace FawryChallenge.Entities
{
    public class Customer
    {
        public string Name { get; }
        public decimal Balance { get; private set; }

        public Customer(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public void DeductBalance(decimal amount)
        {
            if (Balance < amount)
                throw new InvalidOperationException("Insufficient balance");

            Balance -= amount;
        }
    }
}
