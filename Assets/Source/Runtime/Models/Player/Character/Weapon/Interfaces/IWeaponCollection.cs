namespace FPS.Model
{
    public interface IWeaponCollection
    {
        IPlayerWithWeapon Weapon { get; }

        bool CanSwitch { get; }

        IPlayerWithWeapon SwitchNext();
        IPlayerWithWeapon SwitchPrevious();
    }
}