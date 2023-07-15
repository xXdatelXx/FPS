using FPS.Toolkit;
using FPS.Visual;

namespace FPS.GamePlay
{
    public sealed class WeaponView : IWeaponView
    {
        private readonly IWeaponAnimator _animator;
        private readonly IBulletsView _bullets;
        private readonly ICameraShake _camera;

        public WeaponView(IBulletsView bullets, IWeaponAnimator animator, ICameraShake camera)
        {
            _bullets = bullets.ThrowExceptionIfArgumentNull(nameof(bullets));
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));
            _camera = camera.ThrowExceptionIfArgumentNull(nameof(camera));
        }

        public void Shoot()
        {
            _camera.Shake();
            _animator.PlayShoot();
        }

        public void Reload() => _animator.PlayReload();

        public void VisualizeBullets(int bullets) => _bullets.Visualize(bullets);

        public void Equip() => _animator.PlayEnable();

        public void UneQuip() => _animator.PlayDisable();
    }
}