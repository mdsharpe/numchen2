namespace Numchen.Shared
{
    public interface IGameEngine
    {
        int? Current { get; }
        BoardState Board { get; }
        Task MoveCurrentToColumn(int columnIndex);
    }
}
