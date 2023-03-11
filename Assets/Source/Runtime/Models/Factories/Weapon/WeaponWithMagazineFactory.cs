using FPS.Data;
using FPS.Model;
using FPS.Tools;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class WeaponWithMagazineFactory : IFactory<IWeaponWithMagazine>
    {
        [SerializeField] private RaySpawnPoint _bulletSpawnPoint;
        [SerializeField] private FullWeaponData _weaponData;
        [SerializeField] private AnimationCurve _damageCurve;
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _body;
        [SerializeField] private BulletViewFactory _bulletView;
        [SerializeField] private WeaponViewFactory _weaponViewFactory;

        public IWeaponWithMagazine Create()
        {
            var damageCoefficient = new CurveDamageCoefficient(new Curve(_damageCurve));
            var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, _weaponData.Damage, damageCoefficient, _bulletView.Create());
            var magazine = new Magazine(_weaponData.Bullets);
            var delay = new WeaponDelay(new Timer(_weaponData.Delay));
            var recoil = new CurveRecoil(new Curve(_weaponData.RecoilCurve), delay, magazine);
            var weaponView = _weaponViewFactory.Create();
            var head = new GameObjectWithRotation(_head);
            var body = new GameObjectWithRotation(_body);
            var characterRecoilRotation = new CharacterRecoilRotation(head, body);

            var weapon = new Weapon(bulletsFactory, weaponView);
            var weaponWithDelay = new WeaponWithDelay(weapon, delay);
            var handWeapon = new HandWeapon(weaponWithDelay, new Timer(_weaponData.Enable), weaponView);
            var weaponWithRecoil = new WeaponWithRecoil(handWeapon, characterRecoilRotation, recoil);

            var weaponWithMagazine = new WeaponWithMagazine(weaponWithRecoil, magazine, new Timer(_weaponData.Reload), weaponView);

            return weaponWithMagazine;
        }
    }
}