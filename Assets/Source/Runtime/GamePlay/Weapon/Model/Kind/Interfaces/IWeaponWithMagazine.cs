namespace FPS.Model
{
    public interface IWeaponWithMagazine : IWeapon
    {
        bool CanReload { get; }
        void Reload();
    }
}