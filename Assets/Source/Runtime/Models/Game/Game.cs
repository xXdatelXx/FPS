using FPS.Data;
using FPS.Tools.GameLoop;

namespace FPS.Game
{
    public sealed class Game : IGame
    {
        private readonly IGameLoop _gameLoop;

        public Game(IGameEngine engine)
        {
            var time = new GameTime();
            var player = engine.Factories.PlayerFactory.Create(time);
            var weapons = engine.Factories.PlayerWeaponFactory.Create();

            _gameLoop = new GameLoop(time,player, weapons );
        }

        public void Play() => _gameLoop.Start();
    }
}