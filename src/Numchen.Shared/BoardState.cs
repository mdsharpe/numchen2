using System.Collections.Immutable;

namespace Numchen.Shared
{
    public class BoardState
    {
        public BoardState(GameConfiguration config)
        {
            Columns = Enumerable.Range(0, config.ColumnCount)
                .Select(i => new Stack<int>())
                .ToImmutableList();

            Goals = new int[config.ColumnCount];
        }

        public IImmutableList<Stack<int>> Columns { get; }
        public int[] Goals { get; }
    }
}
