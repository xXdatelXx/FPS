using System;
using Source.Runtime.Models.Weapons.Kind.Interfaces;

namespace Source.Runtime.Models.Weapons.Kind
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
            throw new NotImplementedException();
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }
    }
}