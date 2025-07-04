using FawryChallenge.Abstractions;
using FawryChallenge.Service.Abstraction;

namespace FawryChallenge.Service.Implementation
{
    public class ShippingService : IShippingService
    {
        public void ShipItems(IEnumerable<IShippable> items)
        {
            if (!items.Any()) return;

            Console.WriteLine("** Shipment notice **");

            var groupedItems = items
                .GroupBy(i => i.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count(),
                    Weight = g.First().Weight
                });

            double totalWeight = 0;

            foreach (var item in groupedItems)
            {
                Console.WriteLine($"{item.Count}x {item.Name} {item.Weight * 1000}g");
                totalWeight += item.Count * item.Weight;
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine($"total . package weight {totalWeight:0.#}kg");
        }
    }
}
