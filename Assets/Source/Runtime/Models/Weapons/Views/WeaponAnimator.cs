using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Models.Weapons.Views
{
    [RequireComponent(typeof(Animator))]
    public sealed class WeaponAnimator : MonoBehaviour, IWeaponAnimator
    {
        [SerializeField] private string _shoot = nameof(PlayShoot);
        [SerializeField] private string _reload = nameof(PlayReload);
        [SerializeField] private string _enable = "Enable";
        [SerializeField] private string _disable = "Disable";
        private Animator _animator;

        private void Awake()
        {
            _shoot.ThrowExceptionIfNull(nameof(_shoot));
            _reload.ThrowExceptionIfNull(nameof(_reload));
            _enable.ThrowExceptionIfNull(nameof(_enable));
            _disable.ThrowExceptionIfNull(nameof(_disable));

            _animator = GetComponent<Animator>();
        }

        public void PlayShoot() => _animator.Play(_shoot);

        public void PlayReload() => _animator.Play(_reload);

        public void PlayEnable() => _animator.Play(_enable);

        public void PlayDisable() => _animator.Play(_disable);
    }
}