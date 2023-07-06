﻿using FPS.Data;
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
            var weapons = engine.Factories.PlayerWeapon.Create();
            var enemySimulation = engine.Factories.EnemySimulation.Create(character);

            _gameLoop = new GameLoop(time, player, weapons, enemySimulation);
        }

        public void Play() => _gameLoop.Start();
    }
}