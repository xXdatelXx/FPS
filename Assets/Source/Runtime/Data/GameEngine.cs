using FPS.Factories;
using FPS.Tools;

namespace FPS.Data
{
    public sealed class GameEngine : IGameEngine
    {
        public GameEngine(IPlayerFactory playerFactory, IPlayerWeaponCollectionFactory playerWeaponFactory)
        {
            PlayerFactory = playerFactory.ThrowExceptionIfArgumentNull(nameof(PlayerFactory));
            PlayerWeaponFactory = playerWeaponFactory.ThrowExceptionIfArgumentNull(nameof(playerWeaponFactory));
        }

        public IPlayerFactory PlayerFactory { get; }
        public IPlayerWeaponCollectionFactory PlayerWeaponFactory { get; }
    }
}