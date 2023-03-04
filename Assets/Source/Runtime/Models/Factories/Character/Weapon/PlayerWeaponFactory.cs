using FPS.Data;
using FPS.Input;
using FPS.Model;
using FPS.Tools;
using FPS.Views;
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
        [SerializeField] private Transform _head;

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
            var delay = new WeaponDelay(new Timer(_weaponData.Delay));
            var head = new GameObjectWithRotation(_head);

            var weapon = new Weapon(bulletsFactory, view);
            var weaponWithDelay = new WeaponWithDelay(weapon, delay);
            var handWeapon = new HandWeapon(weaponWithDelay, new Timer(_weaponData.Enable), view);
            var weaponWithRecoil = new WeaponWithRecoil(handWeapon, new Curve(_weaponData.RecoilCurve), delay, head, magazine);
            var weaponWithMagazine = new WeaponWithMagazine(weaponWithRecoil, magazine, new Timer(_weaponData.Reload), view);

            return weaponWithMagazine;
        }
    }
}