namespace Numchen.Shared
{
    public interface INumberProducer
    {
        int? Current { get; }
        bool TryMoveNext();
    }
}
