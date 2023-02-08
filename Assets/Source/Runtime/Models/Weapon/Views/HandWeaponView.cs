using FPS.Model.Weapons.Bullet;
using Source.Runtime.Tools.Extensions;
using Source.Runtime.Views.Text;
using UnityEngine;

namespace Source.Runtime.Models.Weapon.Views
{
    public sealed class HandWeaponView
    {
        private readonly Animator _animator;
        private readonly IReadOnlyMagazine _magazine;
        private readonly ITextView _bulletsView;
        public string EnableAnimation { private get; init; } = nameof(Enable);
        public string DisableAnimation { private get; init; } = nameof(Disable);
        
        public HandWeaponView(Animator animator, IReadOnlyMagazine magazine, ITextView bulletsView)
        {
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));
            _magazine = magazine.ThrowExceptionIfArgumentNull(nameof(magazine));
            _bulletsView = bulletsView.ThrowExceptionIfArgumentNull(nameof(bulletsView));
        }
        
        public void Enable()
        {
            _animator.SetTrigger(EnableAnimation);
            _bulletsView.Visualize(_magazine.Bullets.Value.ToString());
        }

        public void Disable() => _animator.SetTrigger(DisableAnimation);
    }
}