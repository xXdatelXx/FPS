using FPS.Factories;
using FPS.Tools;

namespace FPS.Data
{
    public sealed class Factories : IFactories
    {
        public Factories(IPlayerFactory playerFactory, IPlayerWeaponCollectionFactory playerWeaponFactory)
        {
            PlayerFactory = playerFactory.ThrowExceptionIfArgumentNull(nameof(playerFactory));
            PlayerWeaponFactory = playerWeaponFactory.ThrowExceptionIfArgumentNull(nameof(playerWeaponFactory));
        }

        public IPlayerFactory PlayerFactory { get; }
        public IPlayerWeaponCollectionFactory PlayerWeaponFactory { get; }
    }
}