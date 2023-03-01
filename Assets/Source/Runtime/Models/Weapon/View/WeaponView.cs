using FPS.Tools;

namespace FPS.Model
{
    public sealed class WeaponView : IWeaponView
    {
        private readonly IWeaponAnimator _animator;
        private readonly IBulletsView _bullets;

        public WeaponView(IBulletsView bullets, IWeaponAnimator animator)
        {
            _bullets = bullets.ThrowExceptionIfArgumentNull(nameof(bullets));
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));
        }

        public void Shoot() => _animator.PlayShoot();

        public void Reload() => _animator.PlayReload();

        public void VisualizeBullets(int bullets) => _bullets.Visualize(bullets);

        public void Enable() => _animator.PlayEnable();

        public void Disable() => _animator.PlayDisable();
    }
}