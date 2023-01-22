using FPS.Model.Weapons;

namespace Source.Runtime.CompositeRoot.Weapons
{
    public interface ICharacterWeaponFactory
    {
        IWeapon Create();
    }
}