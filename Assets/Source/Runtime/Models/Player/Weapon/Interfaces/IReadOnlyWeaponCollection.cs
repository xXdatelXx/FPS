namespace FPS.Model.Weapon
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