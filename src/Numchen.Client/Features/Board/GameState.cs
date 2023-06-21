using Numchen.Shared;

namespace Numchen.Client.Features.Board
{
    public class GameState
    {
        private readonly GameEngineFactory _factory;
        
        private IGameEngine? _engine;

        public GameState(GameEngineFactory gameEngineFactory)
        {
            _factory = gameEngineFactory;
        }

        public int? NextCard => _engine?.NextCard;
        public BoardState? Board => _engine?.Board;

        public event Action? OnChange;

        public void Initialize(GameType mode)
        {
            _engine = _factory.Create(mode);
        }

        public async Task MoveCurrentToColumn(int columnIndex)
        {
            if (_engine is null)
            {
                throw new InvalidOperationException();
            }

            await _engine.MoveCurrentToColumn(columnIndex);

            NotifyStateHasChanged();
        }

        public async Task RemoveFromColumn(int columnIndex)
        {
            if (_engine is null)
            {
                throw new InvalidOperationException();
            }

            await _engine.RemoveFromColumn(columnIndex);

            NotifyStateHasChanged();
        }

        private void NotifyStateHasChanged()
            => OnChange?.Invoke();
    }
}
