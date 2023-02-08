namespace FPS.Model.Weapons
{
    public interface IWeapon
    {
        bool CanShoot { get; }
        bool CanReload { get; }
        void Shoot();
        void Reload();
    }
}