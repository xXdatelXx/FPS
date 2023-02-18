namespace FPS.Model.Weapon
{
    public interface IReadOnlyWeaponCollection
    {
        IPlayerWeapon Weapon { get; }
        
        bool CanSwitchNext { get; }
        IPlayerWeapon SwitchNext();

        bool CanSwitchPrevious { get; }
        IPlayerWeapon SwitchPrevious();
    }
}