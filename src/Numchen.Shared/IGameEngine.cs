namespace Numchen.Shared
{
    public interface IGameEngine
    {
        int? NextCard { get; }
        BoardState Board { get; }

        Task MoveCurrentToColumn(int columnIndex);
        Task RemoveFromColumn(int columnIndex);
    }
}
