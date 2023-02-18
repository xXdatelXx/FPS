using FPS.Model.Weapon;

namespace Source.Runtime.CompositeRoot.Weapons
{
    public interface IPlayerWeaponFactory
    {
        IPlayerWeapon Create();
    }
}