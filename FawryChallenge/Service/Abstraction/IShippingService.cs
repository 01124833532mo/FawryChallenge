using FawryChallenge.Abstractions;

namespace FawryChallenge.Service.Abstraction
{
    public interface IShippingService
    {
        void ShipItems(IEnumerable<IShippable> items);
    }
}
