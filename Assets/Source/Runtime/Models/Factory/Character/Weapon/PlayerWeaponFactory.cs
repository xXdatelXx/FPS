using FPS.Model;
using FPS.Model.Weapon;
using FPS.Model.Weapons;
using FPS.Model.Weapons.Bullet;
using Source.Runtime.Data.Weapon;
using Source.Runtime.Model.Timer;
using Source.Runtime.Models.Weapon.Views;
using Source.Runtime.Views.Text;
using UnityEngine;

namespace Source.Runtime.CompositeRoot.Weapons
{
    public sealed class PlayerWeaponFactory : MonoBehaviour, IPlayerWeaponFactory
    {
        [SerializeField] private BulletSpawnPoint _bulletSpawnPoint;
        [SerializeField] private FullWeaponData _weaponData;
        [SerializeField] private WeaponAnimator _animator;
        [SerializeField] private TextView _bulletsView;

        public IPlayerWeapon Create()
        {
            var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, _weaponData.Damage);
            var magazine = new Magazine(_weaponData.Bullets);
            var view = new WeaponView(new BulletsView(_bulletsView), _animator);
            var input = new PlayerWeaponInput();

            var weapon = new Weapon(bulletsFactory, view);
            var weaponWithDelay = new WeaponWithDelay(weapon, new Timer(_weaponData.Delay));
            var handWeapon = new HandWeapon(weaponWithDelay, new Timer(_weaponData.Enable), view);
            var weaponWithMagazine = new WeaponWithMagazine(handWeapon, magazine, new Timer(_weaponData.Reload), view);

            var playerWeapon = new PlayerWeapon(weaponWithMagazine, input);
            var playerWeaponWithMagazine = new PlayerWeaponWithMagazine(playerWeapon, weaponWithMagazine, input);

            return playerWeaponWithMagazine;
        }
    }
}