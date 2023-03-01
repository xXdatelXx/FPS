namespace FPS.Model
{
    public interface IReadOnlyWeaponCollection
    {
        IPlayerWithWeapon Weapon { get; }

        bool CanSwitch { get; }

        IPlayerWithWeapon SwitchNext();
        IPlayerWithWeapon SwitchPrevious();
    }
}