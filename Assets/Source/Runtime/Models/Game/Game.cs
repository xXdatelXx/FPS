using FPS.Model;
using Source.Runtime.Loop;
using Source.Runtime.Models.Loop;

namespace Source.Runtime.CompositeRoot
{
    public sealed class Game : IGame
    {
        private readonly IPlayer _player;
        private readonly IGameLoop _gameLoop;
        
        public Game(IGameEngine engine)
        {
            _player = engine.PlayerFactory.Create();
            _gameLoop = new GameLoop(new GameTime());
        }
        
        public void Play()
        {
            _gameLoop.Add(_player);
            _gameLoop.Start();
        }
    }
}