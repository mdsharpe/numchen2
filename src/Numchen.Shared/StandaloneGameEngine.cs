using System.Collections.Immutable;

namespace Numchen.Shared
{
    public class StandaloneGameEngine : IGameEngine
    {
        private readonly Queue<int> _pool;

        public StandaloneGameEngine(GameConfiguration config)
        {
            var rng = new Random();

            _pool = new Queue<int>(
                Enumerable.Repeat(
                    Enumerable.Range(1, config.StackLength), config.ColumnCount)
                .SelectMany(o => o)
                .OrderBy(o => rng.NextDouble()));

            Board = new BoardState(
                Columns: Enumerable.Range(0, config.ColumnCount)
                    .Select<int, IImmutableStack<int>>(i => ImmutableStack<int>.Empty)
                    .ToImmutableList(),
                Goals: new int[config.ColumnCount].ToImmutableList());
        }

        public int? NextCard => _pool.TryPeek(out var next) ? next : null;

        public BoardState Board { get; private set; }

        public Task MoveCurrentToColumn(int columnIndex)
        {
            var numberToMove = NextCard ?? throw new InvalidOperationException();

            MoveNext();

            Board = Board.WithAddCardToColumn(numberToMove, columnIndex);

            return Task.CompletedTask;
        }

        public Task RemoveFromColumn(int columnIndex)
        {
            Board = Board.WithRemoveCardFromColumn(columnIndex);

            return Task.CompletedTask;
        }

        private void MoveNext() => _pool.Dequeue();
    }
}
