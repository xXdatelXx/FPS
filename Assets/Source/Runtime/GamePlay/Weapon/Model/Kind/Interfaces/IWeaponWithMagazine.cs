namespace FPS.GamePlay
{
    public interface IWeaponWithMagazine : IWeapon
    {
        bool CanReload { get; }
        void Reload();
    }
}