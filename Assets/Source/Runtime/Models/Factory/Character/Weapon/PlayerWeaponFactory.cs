using System.Collections.Generic;
using FPS.Model;
using FPS.Model.Weapon;
using FPS.Model.Weapons;
using FPS.Model.Weapons.Bullet;
using Sirenix.OdinInspector;
using Source.Runtime.Model.Timer;
using Source.Runtime.Models.Weapon.Views;
using UnityEngine;

namespace Source.Runtime.CompositeRoot.Weapons
{
    public sealed class PlayerWeaponFactory : SerializedMonoBehaviour, IPlayerWeaponFactory
    {
        [SerializeField, Header("item1 - damage, 2 - reload, 3 - enable, 4 - delay, 5 - bullets, 6 - weaponView, 7 - handWeaponView")]
        private List<(float damage, ITimer reload, ITimer enable, ITimer delay, int bullets, IWeaponView weaponView, IHandWeaponView handWeaponView)> _weapons;

        [SerializeField] private BulletSpawnPoint _bulletSpawnPoint;

        public IPlayerWeapon Create() =>
            new PlayerWeapon(CreateWeaponCollection(), new PlayerWeaponInput());

        private IWeaponCollection<IHandWeapon> CreateWeaponCollection()
        {
            var weaponsCollection = new WeaponCollection<IHandWeapon>();

            foreach (var i in _weapons)
            {
                var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, i.damage);
                var magazine = new Magazine(i.reload, i.bullets);

                var weapon = new Weapon(magazine, bulletsFactory, i.weaponView);
                var delayedWeapon = new DelayedWeapon(weapon, i.delay);
                var handWeapon = new HandWeapon(delayedWeapon, i.enable, i.handWeaponView);

                weaponsCollection.Add(handWeapon);
            }

            return weaponsCollection;
        }
    }
}