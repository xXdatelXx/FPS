namespace FPS.Input
{
    public interface IPlayerWeaponInput
    {
        bool IsShooting { get; }
        bool IsReloading { get; }
        bool IsSwitchNext { get; }
        bool IsSwitchPrevious { get; }
    }
}