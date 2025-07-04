namespace FawryChallenge.Abstractions
{
    public interface IExpirable
    {
        bool IsExpired { get; }
        DateTime ExpiryDate { get; }
    }
}
