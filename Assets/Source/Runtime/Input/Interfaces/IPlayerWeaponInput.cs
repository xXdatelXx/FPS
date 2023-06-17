namespace FPS.Input
{
    public interface IPlayerWeaponInput
    {
        bool Shooting { get; }
        bool Reloading { get; }
        bool SwitchNext { get; }
        bool SwitchPrevious { get; }
    }
}