using FPS.Data;
using FPS.GamePlay;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class WeaponWithMagazineFactory : MonoBehaviour, IFactory<IWeaponWithMagazine>
    {
        [SerializeField] private RaySpawnPoint _bulletSpawnPoint;
        [SerializeField] private WeaponConfig _weaponConfig;
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _body;
        [SerializeField] private BulletViewFactory _bulletView;
        [SerializeField] private WeaponViewFactory _weaponViewFactory;
        [SerializeField] private ProText3D _bulletsText;

        public IWeaponWithMagazine Create()
        {
            var delayTimer = new Timer(_weaponConfig.Delay);
            var equippingTimer = new Timer(_weaponConfig.Enable);
            var reloadTimer = new Timer(_weaponConfig.Reload);
            var gameLoop = new GameLoop(new GameTime(), delayTimer, equippingTimer, reloadTimer);
            gameLoop.Start();

            var damageCoefficient = new CurveDamageCoefficient(new Curve(_weaponConfig.DamageCurve));
            var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, _weaponConfig.Damage, damageCoefficient, _bulletView.Create());
            var magazine = new Magazine(_weaponConfig.Bullets, new MagazineView(_bulletsText));
            var delay = new WeaponDelay(new TimerWithCanceling(delayTimer));
            var recoil = new CurveRecoil(new Curve(_weaponConfig.RecoilCurve), delay, magazine);
            var weaponView = _weaponViewFactory.Create();
            var head = new Rotation(_head);
            var body = new Rotation(_body);
            var characterRecoilRotation = new CharacterRecoilRotation(head, body);
            var reload = new Reload(reloadTimer, weaponView);

            var weapon = new Weapon(bulletsFactory);
            var weaponWithView = new WeaponWithView(weapon, weaponView);
            var weaponWithDelay = new WeaponWithDelay(weaponWithView, delay);
            var handWeapon = new HandWeapon(weaponWithDelay, equippingTimer);
            var weaponWithRecoil = new WeaponWithRecoil(handWeapon, characterRecoilRotation, recoil);
            var weaponWithMagazine = new WeaponWithMagazine(weaponWithRecoil, magazine, reload);

            return weaponWithMagazine;
        }
    }
}