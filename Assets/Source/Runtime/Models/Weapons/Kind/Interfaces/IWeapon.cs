namespace Source.Runtime.Models.Weapons.Kind.Interfaces
{
    public interface IWeapon
    {
        bool CanShoot { get; }
        void Shoot();
        void Enable();
        void Disable();
    }
}