namespace Numchen.Shared
{
    public class GameEngineFactory
    {
        private static readonly GameConfiguration Config = new(6, 16);

        public IGameEngine Create()
        {
            return new StandaloneGameEngine(Config);
        }
    }
}
