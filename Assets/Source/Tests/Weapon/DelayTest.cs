using System;
using FPS.Model;
using FPS.Tools;
using NUnit.Framework;

namespace FPS.Tests
{
    public sealed class DelayTest
    {
        [Test]
        public void CanNotCreateDoubleDelay()
        {
            var wasException = false;

            try
            {
                var delay = new WeaponDelay(new Timer(1));

                delay.Play();
                delay.Play();
            }
            catch (Exception e)
            {
                wasException = true;
            }

            Assert.True(wasException);
        }

        [Test]
        public void WeaponCanNotShootWhileDelayPlaying()
        {
            var weapon = new WeaponWithDelay(new DummyWeapon(), new WeaponDelay(new Timer(1)));
            
            weapon.Enable();
            weapon.Shoot();
            
            Assert.False(weapon.CanShoot);
        }
    }
}