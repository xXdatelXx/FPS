using FPS.Model.Weapons;

namespace FPS.Model.Weapon
{
    public interface IReadOnlyWeaponCollection<TWeapon> where TWeapon : IWeapon
    {
        TWeapon Weapon { get; }
        
        bool CanSwitchNext { get; }
        TWeapon SwitchNext();

        bool CanSwitchPrevious { get; }
        TWeapon SwitchPrevious();
    }
}