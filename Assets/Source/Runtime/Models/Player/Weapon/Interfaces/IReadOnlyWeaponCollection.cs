namespace Source.Runtime.Models.Player.Weapon.Interfaces
{
    public interface IReadOnlyWeaponCollection
    {
        IPlayerWithWeapon Weapon { get; }

        bool CanSwitchNext { get; }
        bool CanSwitchPrevious { get; }
        
        IPlayerWithWeapon SwitchNext();
        IPlayerWithWeapon SwitchPrevious();
    }
}