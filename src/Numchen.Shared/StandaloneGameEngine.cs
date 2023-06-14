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

            MoveNext();
        }

        public int? Current { get; private set; }

        public BoardState Board { get; private set; }

        public Task MoveCurrentToColumn(int columnIndex)
        {
            var numberToMove = Current ?? throw new InvalidOperationException();
            MoveNext();
            Board.Columns[columnIndex].Push(numberToMove);

            return Task.CompletedTask;
        }

        private void MoveNext()
        {
            if (!_pool.TryDequeue(out var next))
            {
                Current = null;
            }

            Current = next;
        }
    }
}
