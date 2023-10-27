namespace FPS.GamePlay
{
    public interface IWeaponCollection
    {
        IPlayerWithWeapon Current { get; }

        bool CanSwitch { get; }

        IPlayerWithWeapon SwitchNext();
        IPlayerWithWeapon SwitchPrevious();
    }
}