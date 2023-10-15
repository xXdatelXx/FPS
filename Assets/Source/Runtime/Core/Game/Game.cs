using FPS.Data;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;

namespace FPS.Core
{
    public sealed class Game : IGame
    {
        private readonly IGameLoop _gameLoop;

        public Game(IGameEngine engine)
        {
            var time = new GameTime();
            var character = engine.Factories.Character.Create(time);
            var player = engine.Factories.Player.Create(character);
            var lose = engine.Factories.LoseFactory.Create(character.Score);
            var weapons = engine.Factories.PlayerWeapon.Create();
            var enemySimulation = engine.Factories.EnemySimulation.Create(character);
            new GameCursor().Hide();

            _gameLoop = new GameLoop(time, player, weapons, enemySimulation);
        }

        public void Play() => _gameLoop.Start();
    }
}