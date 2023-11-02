using FPS.Data;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;

namespace FPS.Core
{
    public sealed class Game : IGame
    {
        private readonly IGameLoop _gameLoop;

        public Game(GameFactories factories)
        {
            var time = new GameTime();
            var character = factories.Character.Create(time);
            var player = factories.Player.Create(character);
            var lose = factories.LoseFactory.Create(character.Score);
            var weapons = factories.PlayerWeapon.Create();
            var enemySimulation = factories.EnemySimulation.Create(character);
            new GameCursor().Hide();

            _gameLoop = new GameLoop(time, player, weapons, enemySimulation);
        }

        public void Play() => _gameLoop.Start();
    }
}