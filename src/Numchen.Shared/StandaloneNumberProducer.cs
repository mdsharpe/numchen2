namespace Numchen.Shared
{
    public class StandaloneNumberProducer : INumberProducer
    {
        private readonly Queue<int> _pool;

        public StandaloneNumberProducer(GameConfiguration config)
        {
            var rng = new Random();

            _pool = new Queue<int>(
                Enumerable.Repeat(
                    Enumerable.Range(1, config.StackLength), config.ColumnCount)
                .SelectMany(o => o)
                .OrderBy(o => rng.NextDouble()));
        }

        public int? Current { get; private set; }

        public bool TryMoveNext()
        {
            if (!_pool.TryDequeue(out var next))
            {
                Current = null;
                return false;
            }

            Current = next;
            return true;
        }
    }
}
