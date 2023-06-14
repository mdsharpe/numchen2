namespace Numchen.Shared
{
    public static class BoardStateExtensions
    {
        public static BoardState WithAddCardToColumn(this BoardState board, int card, int columnIndex)
        {
            var column = board.Columns[columnIndex];
            var newColumn = column.Push(card);
            var newColumns = board.Columns.SetItem(columnIndex, newColumn);
            return board with { Columns = newColumns };
        }
    }
}
