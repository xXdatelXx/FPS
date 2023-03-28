using FPS.Model;

namespace FPS.Tests
{
    public sealed class DummyWeapon : IWeapon
    {
        public bool CanShoot => true;

        public void Shoot()
        { }

        public void Enable()
        { }

        public void Disable()
        { }
    }
}