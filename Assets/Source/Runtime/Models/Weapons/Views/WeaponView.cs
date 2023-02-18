using Source.Runtime.Tools.Extensions;
using Source.Runtime.Views.Text;

namespace Source.Runtime.Models.Weapon.Views
{
    public sealed class WeaponView : IWeaponView
    {
        private readonly ITextView _bulletsView;
        private readonly IWeaponAnimator _animator;

        public WeaponView(ITextView bulletsView, IWeaponAnimator animator)
        {
            _bulletsView = bulletsView.ThrowExceptionIfArgumentNull(nameof(bulletsView));
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));
        }

        public void OnShoot() => _animator.PlayShoot();

        public void OnReload() => _animator.PlayReload();

        public void VisualizeBullets(int bullets) => _bulletsView.Visualize(bullets);

        public void OnEnable() => _animator.PlayEnable();

        public void OnDisable() => _animator.PlayDisable();
    }
}