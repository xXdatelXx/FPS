using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class WeaponViewWithSounds : IWeaponView
    {
        private readonly IWeaponView _view;
        private readonly IWeaponAudio _audio;

        public WeaponViewWithSounds(IWeaponView view, IWeaponAudio audio)
        {
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            _audio = audio.ThrowExceptionIfArgumentNull(nameof(audio));
        }

        public void Shoot()
        {
            _audio.Shoot();
            _view.Shoot();
        }

        public void Reload()
        {
            _audio.Reload();
            _view.Reload();
        }

        public void Equip()
        {
            _audio.Equip();
            _view.Equip();
        }

        public void UneQuip()
        {
            _audio.UneQuip();
            _view.UneQuip();
        }
    }
}