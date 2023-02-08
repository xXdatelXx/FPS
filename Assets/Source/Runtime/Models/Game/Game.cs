using FPS.Model;
using FPS.Model.Weapon;
using Source.Runtime.Loop;
using Source.Runtime.Models.Loop;

namespace Source.Runtime.CompositeRoot
{
    public sealed class Game : IGame
    {
        private readonly IPlayer _player;
        private readonly IPlayerWeapon _weapon;
        private readonly IGameLoop _gameLoop;
        
        public Game(IGameEngine engine)
        {
            var time = new GameTime();
            _player = engine.PlayerFactory.Create(time);
            _weapon = engine.PlayerWeaponFactory.Create();
            _gameLoop = new GameLoop(time);
        }
        
        public void Play()
        {
            _gameLoop.Add(_player);
            _gameLoop.Add(_weapon);
            _gameLoop.Start();
        }
    }
}