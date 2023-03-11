using FPS.Tools;

namespace FPS.Model
{
    public sealed class WeaponAnimator : IWeaponAnimator
    {
        private readonly IAnimation _shoot;
        private readonly IAnimation _reload;
        private readonly IAnimation _enable;
        private readonly IAnimation _disable;

        public WeaponAnimator(IAnimation shoot, IAnimation reload, IAnimation enable, IAnimation disable)
        {
            _shoot = shoot.ThrowExceptionIfArgumentNull(nameof(shoot));
            _reload = reload.ThrowExceptionIfArgumentNull(nameof(reload));
            _enable = enable.ThrowExceptionIfArgumentNull(nameof(enable));
            _disable = disable.ThrowExceptionIfArgumentNull(nameof(disable));
        }

        public void PlayShoot() => _shoot.Play();
        public void PlayReload() => _reload.Play();
        public void PlayEnable() => _enable.Play();
        public void PlayDisable() => _disable.Play();
    }
}