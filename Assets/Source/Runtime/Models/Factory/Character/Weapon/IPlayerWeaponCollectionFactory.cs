using FPS.Model.Weapon;

namespace Source.Runtime.CompositeRoot.Weapons
{
    public interface IPlayerWeaponCollectionFactory
    {
        IPlayerWeapon Create();
    }
}