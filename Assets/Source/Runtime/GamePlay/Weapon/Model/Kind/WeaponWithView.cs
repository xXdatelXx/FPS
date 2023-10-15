using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class WeaponWithView : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly IWeaponView _view;

        public WeaponWithView(IWeapon weapon, IWeaponView view)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public bool CanShoot => _weapon.CanShoot;
        
        public void Shoot()
        {
            _weapon.Shoot();
            _view.Shoot();
        }

        public void Enable()
        {
            _weapon.Enable();
            _view.Equip();
        }

        public void Disable()
        {
            _weapon.Disable();
            _view.UneQuip();
        }
    }
}