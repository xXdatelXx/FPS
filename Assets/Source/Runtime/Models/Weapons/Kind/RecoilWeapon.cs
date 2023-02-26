using Source.Runtime.Models.Weapons.Kind.Interfaces;
using Source.Runtime.Tools.Math;
using Source.Runtime.Tools.Timer;

namespace Source.Runtime.Models.Weapons.Kind
{   
    public sealed class RecoilWeapon : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly ITimer _delay;
        private ICurve _curve;
        public bool CanShoot => _weapon.CanShoot;

        public void Shoot()
        {
            _weapon.Shoot();
            Recoil();
        }

        public void Enable() => _weapon.Enable();

        public void Disable()
        {
            _weapon.Disable();

            if (_delay.Playing)
                _delay.Cancel();
        }

        private async void Recoil()
        {
            
            
            _delay.Play();
            await _delay.End();
            StopRecoil();
        }
        
        private void StopRecoil()
        {
            
        }
    }
}