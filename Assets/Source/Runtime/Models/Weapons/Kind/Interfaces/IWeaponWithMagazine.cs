namespace FPS.Model.Weapons
{
    public interface IWeaponWithMagazine : IWeapon
    {
        bool CanReload { get; }
        void Reload();
    }
}