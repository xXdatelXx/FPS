using Source.Runtime.Data;
using Source.Runtime.Models.Game.Loop;
using Source.Runtime.Models.Game.Loop.Time;
using Source.Runtime.Models.Player;
using Source.Runtime.Models.Player.Weapon.Interfaces;

namespace Source.Runtime.Models.Game
{
    public sealed class Game : IGame
    {
        private readonly IGameLoop _gameLoop;
        private readonly IPlayer _player;
        private readonly IPlayerWeapons _weapons;

        public Game(IGameEngine engine)
        {
            var time = new GameTime();
            _player = engine.PlayerFactory.Create(time);
            _weapons = engine.PlayerWeaponFactory.Create();
            _gameLoop = new GameLoop(time);
        }

        public void Play()
        {
            _gameLoop.Add(_player);
            _gameLoop.Add(_weapons);
            _gameLoop.Start();
        }
    }
}