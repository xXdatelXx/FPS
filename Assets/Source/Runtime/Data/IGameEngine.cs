using Source.Runtime.CompositeRoot.Weapons;

namespace Source.Runtime.CompositeRoot
{
    public interface IGameEngine
    {
        IPlayerFactory PlayerFactory { get; }
        IPlayerWeaponCollectionFactory PlayerWeaponFactory { get; }
    }
}