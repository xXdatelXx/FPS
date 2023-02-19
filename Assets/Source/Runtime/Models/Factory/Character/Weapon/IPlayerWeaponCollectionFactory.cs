using Source.Runtime.Models.Player.Weapon.Interfaces;

namespace Source.Runtime.Models.Factory.Character.Weapon
{
    public interface IPlayerWeaponCollectionFactory
    {
        IPlayerWeapons Create();
    }
}