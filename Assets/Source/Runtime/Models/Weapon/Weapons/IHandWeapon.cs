namespace FPS.Model.Weapons
{
    public interface IHandWeapon : IWeapon
    {
        void Enable();
        void Disable();
    }
}