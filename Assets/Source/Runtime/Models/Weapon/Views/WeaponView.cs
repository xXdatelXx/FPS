using FPS.Model.Weapons.Bullet;
using Source.Runtime.Tools.Extensions;
using Source.Runtime.Views.Text;
using UnityEngine;

namespace Source.Runtime.Models.Weapon.Views
{
    public sealed class WeaponView : IWeaponView
    {
        private readonly Animator _animator;
        private readonly IReadOnlyMagazine _magazine;
        private readonly ITextView _bulletsView;
        public string ShootAnimation { private get; init; } = nameof(Shoot);
        public string ReloadAnimation { private get; init; } = nameof(Reload);
    
        public WeaponView(Animator animator, IReadOnlyMagazine magazine, ITextView bulletsView)
        {
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));
            _magazine = magazine.ThrowExceptionIfArgumentNull(nameof(magazine));
            _bulletsView = bulletsView.ThrowExceptionIfArgumentNull(nameof(bulletsView));
        }

        public void Shoot()
        {
            _animator.SetTrigger(ShootAnimation);
            _bulletsView.Visualize(_magazine.Bullets.Value.ToString());
        }

        public void Reload()
        {
            _animator.SetTrigger(ReloadAnimation);
            _bulletsView.Visualize(_magazine.Bullets.Standard.ToString());
        }
    }
}