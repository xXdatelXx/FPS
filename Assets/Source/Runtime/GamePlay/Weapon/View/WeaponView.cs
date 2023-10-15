using FPS.Toolkit;
using FPS.Visual;

namespace FPS.GamePlay
{
    public sealed class WeaponView : IWeaponView
    {
        private readonly IWeaponAnimator _animator;
        private readonly ICameraShake _camera;

        public WeaponView(IWeaponAnimator animator, ICameraShake camera)
        {
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));
            _camera = camera.ThrowExceptionIfArgumentNull(nameof(camera));
        }

        public void Shoot()
        {
            _camera.Shake();
            _animator.PlayShoot();
        }

        public void Reload() => _animator.PlayReload();

        public void Equip() => _animator.PlayEnable();

        public void UneQuip() => _animator.PlayDisable();
    }
}