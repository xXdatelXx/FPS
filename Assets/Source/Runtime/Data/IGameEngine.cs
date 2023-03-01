using FPS.Factories;

namespace FPS.Data
{
    public interface IGameEngine
    {
        IPlayerFactory PlayerFactory { get; }
        IPlayerWeaponCollectionFactory PlayerWeaponFactory { get; }
    }
}