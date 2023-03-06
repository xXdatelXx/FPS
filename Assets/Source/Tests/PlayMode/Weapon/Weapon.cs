using FPS.Model;
using FPS.Tools;
using NUnit.Framework;
using UnityEngine;

namespace FPS.Tests.PlayMode
{
    [TestFixture]
    public sealed class Weapon
    {
        private IHealth _targetHealth;
        private IWeapon _weapon;

        [SetUp]
        public void SetUp()
        {
            _targetHealth = new Health(1);

            var target = Object.Instantiate(new GameObject());
            target.AddComponent<BoxCollider>().size = Vector3.one;
            target.AddComponent<CharacterOrgan>().Construct(_targetHealth, 1);

            var bulletSpawnPoint = Object.Instantiate(new GameObject()).AddComponent<RaySpawnPoint>();
            var bulletFactory = new RayBulletFactory(bulletSpawnPoint, 1, new DamageCoefficient(1));

            _weapon = new Model.Weapon(bulletFactory);
        }

        [Test]
        public void WeaponShootCorrectly()
        {
            _weapon.Shoot();
            Assert.AreEqual(_targetHealth.Died, true);
        }
    }
}