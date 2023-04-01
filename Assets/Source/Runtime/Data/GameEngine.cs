using FPS.Tools;

namespace FPS.Data
{
    public sealed class GameEngine : IGameEngine
    {
        public GameEngine(IFactories factories)
        {
            Factories = factories.ThrowExceptionIfArgumentNull(nameof(factories));
        }

        public IFactories Factories { get; }
    }
}