using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Models.Weapon.Views
{
    public sealed class WeaponView : IWeaponView
    {
        private readonly IWeaponAnimator _animator;
        private readonly IBulletView _bullets;

        public WeaponView(IBulletView bullets, IWeaponAnimator animator)
        {
            _bullets = bullets.ThrowExceptionIfArgumentNull(nameof(bullets));
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));
        }

        public void OnShoot() => _animator.PlayShoot();

        public void OnReload() => _animator.PlayReload();

        public void VisualizeBullets(int bullets) => _bullets.Visualize(bullets);

        public void OnEnable() => _animator.PlayEnable();

        public void OnDisable() => _animator.PlayDisable();
    }
}