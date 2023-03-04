using FPS.Tools;
using FPS.Views;

namespace FPS.Model
{
    public sealed class WeaponWithRecoil : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly ICurve _recoilCurve;
        private readonly IWeaponTrigger _trigger;
        private readonly IGameObjectWithRotation _rotationObject;
        private readonly FloatWithStep _recoilProgress;

        public WeaponWithRecoil(IWeapon weapon, ICurve recoilCurve, IWeaponTrigger trigger, IGameObjectWithRotation rotationObject, IReadOnlyMagazine magazine)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _recoilCurve = recoilCurve.ThrowExceptionIfArgumentNull(nameof(recoilCurve));
            _trigger = trigger.ThrowExceptionIfArgumentNull(nameof(trigger));
            _rotationObject = rotationObject.ThrowExceptionIfArgumentNull(nameof(rotationObject));
            _recoilProgress = new (_recoilCurve.Time / magazine.Bullets);
        }

        public bool CanShoot => _weapon.CanShoot;

        public void Shoot()
        {
            _trigger.Press();
            _weapon.Shoot();
            Recoil();
        }

        public void Enable() => _weapon.Enable();

        public void Disable()
        {
            _weapon.Disable();
            StopRecoil();
        }

        private async void Recoil()
        {
            _recoilProgress.Update();
            _rotationObject.Rotate(new(_recoilCurve[_recoilProgress.Value], _recoilProgress.Value));

            await _trigger.WaitUnPress();

            StopRecoil();
        }

        private void StopRecoil() => _recoilProgress.Reset();
    }
}