using FPS.Model;
using FPS.Tools;
using NUnit.Framework;
using UnityEngine;
using GameObject = UnityEngine.GameObject;

namespace FPS.Tests.PlayMode
{
    [TestFixture]
    internal sealed class WeaponTest
    {
        private IHealth _targetHealth;
        private IWeapon _weapon;

        [SetUp]
        public void SetUp()
        {
            var bulletsSpawnPoint = Object.Instantiate(new GameObject()).AddComponent<RaySpawnPoint>();

            var target = Object.Instantiate(new GameObject());
            _targetHealth = new Health(1);
            target.transform.position = bulletsSpawnPoint.Forward;
            target.AddComponent<BoxCollider>().size = Vector3.one;
            target.AddComponent<CharacterOrgan>().Construct(_targetHealth, 1);

            var bulletFactory = new RayBulletFactory(bulletsSpawnPoint, 1, new DamageCoefficient(1));
            _weapon = new Weapon(bulletFactory);
        }

        [Test]
        public void WeaponShootCorrectly()
        {
            _weapon.Enable();
            _weapon.Shoot();

            Assert.True(_targetHealth.Died);
        }
    }
}