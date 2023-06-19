namespace FPS.GamePlay
{
    public interface IWeapon
    {
        bool CanShoot { get; }
        void Shoot();
        void Enable();
        void Disable();
    }
}