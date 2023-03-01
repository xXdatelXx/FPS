namespace FPS.Model
{
    public interface IWeapon
    {
        bool CanShoot { get; }
        void Shoot();
        void Enable();
        void Disable();
    }
}