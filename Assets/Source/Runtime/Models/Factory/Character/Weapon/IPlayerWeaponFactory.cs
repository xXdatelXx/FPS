using FPS.Model.Weapons;

namespace Source.Runtime.CompositeRoot.Weapons
{
    public interface IPlayerWeaponFactory
    {
        IHandWeapon Create();
    }
}