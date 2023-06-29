namespace Numchen.Shared;

public static class BoardStateExtensions
{
    public static BoardState WithAddCardToColumn(this BoardState board, int card, int columnIndex)
        => board with
        {
            Columns = board.Columns.SetItem(
                columnIndex,
                board.Columns[columnIndex].Push(card))
        };

    public static BoardState WithRemoveCardFromColumn(this BoardState board, int columnIndex)
    {
        var cardValue = board.Columns[columnIndex].Peek();

        var targetGoal = board.Goals
            .Select((o, i) => new { Index = i, Value = o })
            .FirstOrDefault(o => o.Value == cardValue - 1);

        if (targetGoal is null)
        {
            throw new InvalidOperationException($"Card {cardValue} cannot be removed from column {columnIndex}; no suitable goal found.");
        }

        return board with
        {
            Columns = board.Columns.SetItem(
                columnIndex,
                board.Columns[columnIndex].Pop()),
            Goals = board.Goals.SetItem(
                targetGoal.Index,
                cardValue)
        };
    }
}
