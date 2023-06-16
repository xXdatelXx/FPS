using FPS.Model;

namespace FPS.Tests
{
    internal sealed class DummyWeapon : IWeapon
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