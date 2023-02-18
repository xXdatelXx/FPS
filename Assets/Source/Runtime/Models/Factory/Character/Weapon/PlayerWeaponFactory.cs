using FPS.Model;
using FPS.Model.Weapon;
using FPS.Model.Weapons;
using FPS.Model.Weapons.Bullet;
using Source.Runtime.Model.Timer;
using Source.Runtime.Models.Weapon.Views;
using Source.Runtime.Views.Text;
using UnityEngine;

namespace Source.Runtime.CompositeRoot.Weapons
{
    public sealed class PlayerWeaponFactory : MonoBehaviour, IPlayerWeaponFactory
    {
        [SerializeField] private BulletSpawnPoint _bulletSpawnPoint;
        [SerializeField] private float _damage;
        [SerializeField] private Timer _reload;
        [SerializeField] private Timer _delay;
        [SerializeField] private Timer _enable;
        [SerializeField] private int _bullets;
        [SerializeField] private WeaponAnimator _animator;
        [SerializeField] private TextView _bulletsView;

        public IPlayerWeapon Create()
        {
            var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, _damage);
            var magazine = new Magazine(_bullets);
            var view = new WeaponView(new BulletsView(_bulletsView), _animator);
            var input = new PlayerWeaponInput();

            var weapon = new Weapon(bulletsFactory, view);
            var weaponWithDelay = new WeaponWithDelay(weapon, _delay);
            var handWeapon = new HandWeapon(weaponWithDelay, _enable, view);
            var weaponWithMagazine = new WeaponWithMagazine(handWeapon, magazine, _reload, view);

            var playerWeapon = new PlayerWeapon(weaponWithMagazine, input);
            var playerWeaponWithMagazine = new PlayerWeaponWithMagazine(playerWeapon, weaponWithMagazine, input);

            return playerWeaponWithMagazine;
        }
    }
}