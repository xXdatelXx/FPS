using FPS.Model;
using FPS.Model.Weapon;
using FPS.Model.Weapons;
using FPS.Model.Weapons.Bullet;
using UnityEngine;
using Source.Runtime.Model.Timer;
using Source.Runtime.Models.Weapon.Views;
using Source.Runtime.Views.Text;

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
        [SerializeField] private TextView _bulletsView;
        [SerializeField] private WeaponAnimator _animator;

        public IHandWeapon Create()
        {
            var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, _damage);
            var magazine = new Magazine(_bullets);
            var view = new WeaponView(_bulletsView, _animator);
            var input = new PlayerWeaponInput();
            
            var weapon = new Weapon(bulletsFactory, view);
            var weaponWithDelay = new WeaponWithDelay(weapon, _delay);
            var weaponWithMagazine = new WeaponWithMagazine(weapon, magazine, _reload, view);
            
            IPlayerWeapon player = new PlayerWeapon()
            player = new PlayerWeaponWithMagazine(player, weaponWithMagazine, input);
            
            return new HandWeapon(weapon, _enable, view);
        }
    }
}