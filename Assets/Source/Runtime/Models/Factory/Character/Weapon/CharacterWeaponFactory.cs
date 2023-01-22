using FPS.Model.Weapons;
using FPS.Model.Weapons.Bullet;
using Sirenix.OdinInspector;
using Source.Runtime.Model.Timer;
using UnityEngine;

namespace Source.Runtime.CompositeRoot.Weapons
{
    public sealed class CharacterWeaponFactory : SerializedMonoBehaviour, ICharacterWeaponFactory
    {
        [SerializeField] private BulletSpawnPoint _bulletSpawnPoint;
        [SerializeField] private float _damage;
        [SerializeField] private Timer _reload;
        [SerializeField] private Timer _delay;
        [SerializeField, Range(0, 100)] private int _bulletsCount;

        public IWeapon Create()
        {
            var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, _damage);
            var magazine = new Magazine(_reload, _bulletsCount);

            return new Weapon(magazine, _delay, bulletsFactory);
        }
    }
}