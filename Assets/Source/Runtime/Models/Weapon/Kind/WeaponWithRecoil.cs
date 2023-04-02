using FPS.Tools;

namespace FPS.Model
{
    public sealed class WeaponWithRecoil : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly IRotation _rotationObject;
        private readonly IRecoil _recoil;

        public WeaponWithRecoil(IWeapon weapon, IRotation rotationObject, IRecoil recoil)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _rotationObject = rotationObject.ThrowExceptionIfArgumentNull(nameof(rotationObject));
            _recoil = recoil.ThrowExceptionIfArgumentNull(nameof(recoil));
        }

        public bool CanShoot => _weapon.CanShoot;

        public void Shoot()
        {
            _weapon.Shoot();
            _rotationObject.Rotate(_recoil.Next());
        }

        public void Enable() => _weapon.Enable();
        public void Disable() => _weapon.Disable();
    }
}