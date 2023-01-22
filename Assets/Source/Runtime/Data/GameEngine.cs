using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.CompositeRoot
{
    public class GameEngine : IGameEngine
    {
        public IPlayerFactory PlayerFactory { get; }

        public GameEngine(IPlayerFactory playerFactory) => 
            PlayerFactory = playerFactory.ThrowExceptionIfArgumentNull(nameof(PlayerFactory));
    }
}