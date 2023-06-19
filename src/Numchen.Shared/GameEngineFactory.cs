namespace Numchen.Shared
{
    public class GameEngineFactory
    {
        private static readonly GameConfiguration Config = new(6, 16);

        public IGameEngine Create(GameType mode)
            => mode switch
            {
                GameType.Local => new StandaloneGameEngine(Config),
                _ => throw new NotSupportedException(),
            };
    }
}
