namespace FPS.Model.Weapons
{
    public sealed class RecoilWeapon : IWeapon
    {
        private readonly IWeapon _weapon;
        // private readonly IRecoil _recoil;
        public bool CanShoot => _weapon.CanShoot;
        public bool CanReload => _weapon.CanReload;

        public void Shoot()
        {
            _weapon.Shoot();
            // _recoil.
        }

        public void Reload() => _weapon.Reload();
    }
}