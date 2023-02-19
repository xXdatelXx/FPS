using Source.Runtime.CompositeRoot;
using Source.Runtime.CompositeRoot.Weapons;

namespace Source.Runtime.Data
{
    public interface IGameEngine
    {
        IPlayerFactory PlayerFactory { get; }
        IPlayerWeaponCollectionFactory PlayerWeaponFactory { get; }
    }
}