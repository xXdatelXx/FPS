using FPS.Tools;
using FPS.Views;

namespace FPS.Model
{
    public sealed class WeaponWithRecoil : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly ICurve _recoilCurve;
        private readonly IReadOnlyWeaponDelay _delay;
        private readonly IGameObjectWithRotation _head;
        private readonly float _curveStep;
        private float _curveId;

        public WeaponWithRecoil(IWeapon weapon, ICurve recoilCurve, IReadOnlyWeaponDelay delay, IGameObjectWithRotation head, IReadOnlyMagazine magazine)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _recoilCurve = recoilCurve.ThrowExceptionIfArgumentNull(nameof(recoilCurve));
            _delay = delay.ThrowExceptionIfArgumentNull(nameof(delay));
            _head = head.ThrowExceptionIfArgumentNull(nameof(head));
            _curveStep = _recoilCurve.Time / magazine.Bullets;
        }
        
        public bool CanShoot => _weapon.CanShoot;

        public void Shoot()
        {
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
            _curveId += _curveStep;
            _head.Rotate(new(_recoilCurve[_curveId], _curveId));
            await _delay.End();
            StopRecoil();
        }

        private void StopRecoil() => _curveId = 0;
    }
}