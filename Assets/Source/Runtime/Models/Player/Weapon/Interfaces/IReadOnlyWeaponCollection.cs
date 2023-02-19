namespace Source.Runtime.Models.Player.Weapon.Interfaces
{
    public interface IReadOnlyWeaponCollection
    {
        IPlayerWeapon Weapon { get; }

        bool CanSwitchNext { get; }

        bool CanSwitchPrevious { get; }
        IPlayerWeapon SwitchNext();
        IPlayerWeapon SwitchPrevious();
    }
}