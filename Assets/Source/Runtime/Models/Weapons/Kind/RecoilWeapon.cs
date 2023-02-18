namespace FPS.Model.Weapons
{
    public sealed class RecoilWeapon : IWeapon
    {
        private readonly IWeapon _weapon;
        // private readonly IRecoil _recoil;
        public bool CanShoot => _weapon.CanShoot;

        public void Shoot()
        {
            _weapon.Shoot();
            // _recoil.
        }

        public void Enable()
        {
            throw new System.NotImplementedException();
        }

        public void Disable()
        {
            throw new System.NotImplementedException();
        }
    }
}