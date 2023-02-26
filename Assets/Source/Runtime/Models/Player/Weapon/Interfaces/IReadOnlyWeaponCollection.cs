namespace Source.Runtime.Models.Player.Weapon.Interfaces
{
    public interface IReadOnlyWeaponCollection
    {
        IPlayerWithWeapon Weapon { get; }

        bool CanSwitch { get; }
        
        IPlayerWithWeapon SwitchNext();
        IPlayerWithWeapon SwitchPrevious();
    }
}