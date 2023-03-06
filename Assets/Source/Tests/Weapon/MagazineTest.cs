using System;
using FPS.Model;
using FPS.Tools;
using NUnit.Framework;

namespace FPS.Tests
{
    public sealed class MagazineTest
    {
        [Test]
        public void CanNotGetBulletInEmptyMagazine()
        {
            var magazine = new Magazine(1);

            magazine.Get();

            Assert.False(magazine.CanGet);
        }

        [Test]
        public void ThrowExceptionIfTakeFromEmptyMagazine()
        {
            var wasException = false;

            try
            {
                new Magazine(0).Get();
            }
            catch (Exception e)
            {
                wasException = true;
            }


            Assert.True(wasException);
        }

        [Test]
        public void ResetWorkCorrectly()
        {
            var magazine = new Magazine(1);

            magazine.Get();
            magazine.Reset();

            Assert.AreEqual(magazine.Bullets, 1);
        }

        [Test]
        public void WeaponCanNotShootWhileMagazineIsEmpty()
        {
            var weapon = new WeaponWithMagazine(new DummyWeapon(), new Magazine(1), new Timer(0));
            
            weapon.Enable();
            weapon.Shoot();
            
            Assert.False(weapon.CanShoot);
        }
    }
}