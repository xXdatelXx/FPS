using FPS.Data;
using FPS.Model;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class WeaponWithMagazineFactory : MonoBehaviour, IFactory<IWeaponWithMagazine>
    {
        [SerializeField] private RaySpawnPoint _bulletSpawnPoint;
        [SerializeField] private FullWeaponData _weaponData;
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _body;
        [SerializeField] private BulletViewFactory _bulletView;
        [SerializeField] private WeaponViewFactory _weaponViewFactory;

        public IWeaponWithMagazine Create()
        {
            var delayTimer = new Timer(_weaponData.Delay);
            var handWeaponTimer = new Timer(_weaponData.Enable);
            var weaponWithMagazineTimer = new Timer(_weaponData.Reload);
            var gameLoop = new GameLoop(new GameTime(), delayTimer, handWeaponTimer, weaponWithMagazineTimer);
            gameLoop.Start();

            var damageCoefficient = new CurveDamageCoefficient(new Curve(_weaponData.DamageCurve));
            var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, _weaponData.Damage, damageCoefficient, _bulletView.Create());
            var magazine = new Magazine(_weaponData.Bullets);
            var delay = new WeaponDelay(new TimerWithCanceling(delayTimer));
            var recoil = new CurveRecoil(new Curve(_weaponData.RecoilCurve), delay, magazine);
            var weaponView = _weaponViewFactory.Create();
            var head = new Rotation(_head);
            var body = new Rotation(_body);
            var characterRecoilRotation = new CharacterRecoilRotation(head, body);

            var weapon = new Weapon(bulletsFactory, weaponView);
            var weaponWithDelay = new WeaponWithDelay(weapon, delay);
            var handWeapon = new HandWeapon(weaponWithDelay, new TimerWithCanceling(handWeaponTimer), weaponView);
            var weaponWithRecoil = new WeaponWithRecoil(handWeapon, characterRecoilRotation, recoil);

            var weaponWithMagazine = new WeaponWithMagazine(weaponWithRecoil, magazine, new TimerWithCanceling(weaponWithMagazineTimer), weaponView);

            return weaponWithMagazine;
        }
    }
}