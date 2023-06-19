using Numchen.Shared;

namespace Numchen.Client.Features.Board
{
    public class GameState
    {
        private readonly GameEngineFactory _factory;
        
        private IGameEngine _engine;

        public GameState(GameEngineFactory gameEngineFactory)
        {
            _factory = gameEngineFactory;
        }

        public int? NextCard { get; private set; }

        public BoardState? Board { get; private set; }

        public event Action? OnChange;

        public void Initialize(GameType mode)
        {
            _engine = _factory.Create(mode);
            Board = _engine.Board;
        }

        public void MoveCurrentToColumn(int columnIndex)
        {
            if (Board is null)
            {
                throw new InvalidOperationException();
            }

            if (NextCard is null)
            {
                throw new InvalidOperationException();
            }

            Board = Board.WithAddCardToColumn(NextCard.Value, columnIndex);

            NotifyStateHasChanged();
        }

        private void NotifyStateHasChanged()
            => OnChange?.Invoke();
    }
}
