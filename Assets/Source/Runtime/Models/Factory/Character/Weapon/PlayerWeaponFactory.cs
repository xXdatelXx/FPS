using FPS.Data;
using FPS.Input;
using FPS.Model;
using FPS.Tools;
using FPS.Views.Text;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class PlayerWeaponFactory : MonoBehaviour, IPlayerWeaponFactory
    {
        [SerializeField] private RaySpawnPoint _bulletSpawnPoint;
        [SerializeField] private FullWeaponData _weaponData;
        [SerializeField] private WeaponAnimator _animator;
        [SerializeField] private UnityText _bulletsText;
        [SerializeField] private AnimationCurve _damageCurve;

        public IPlayerWithWeapon Create()
        {
            var input = new PlayerWeaponInput();
            var weapon = CreateWeapon();

            var playerWeapon = new PlayerWithWeapon(weapon, input);
            var playerWeaponWithMagazine = new PlayerWeaponWithMagazine(playerWeapon, weapon, input);

            return playerWeaponWithMagazine;
        }

        private IWeaponWithMagazine CreateWeapon()
        {
            var damageCoefficient = new CurveDamageCoefficient(new Curve(_damageCurve));
            var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, _weaponData.Damage, damageCoefficient, new BulletView());
            var magazine = new Magazine(_weaponData.Bullets);
            var view = new WeaponView(new BulletsesView(new TextView(_bulletsText)), _animator);

            var weapon = new Weapon(bulletsFactory, view);
            var weaponWithDelay = new WeaponWithDelay(weapon, new Timer(_weaponData.Delay));
            var handWeapon = new HandWeapon(weaponWithDelay, new Timer(_weaponData.Enable), view);
            var weaponWithMagazine = new WeaponWithMagazine(handWeapon, magazine, new Timer(_weaponData.Reload), view);

            return weaponWithMagazine;
        }
    }
}