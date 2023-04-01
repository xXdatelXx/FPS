using FPS.Factories;

namespace FPS.Data
{
    public interface IFactories
    {
        IPlayerFactory PlayerFactory { get; }
        IPlayerWeaponCollectionFactory PlayerWeaponFactory { get; }
    }
}