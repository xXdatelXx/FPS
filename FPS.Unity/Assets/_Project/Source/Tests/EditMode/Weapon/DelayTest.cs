using System;
using FPS.GamePlay;
using FPS.Toolkit;
using NUnit.Framework;

namespace FPS.Tests
{
    internal sealed class DelayTest
    {
        [Test]
        public void CanNotCreateDoubleDelay()
        {
            var delay = new WeaponDelay(new WeaponDelay(new TimerWithCanceling(new Timer(1))));

            Assert.Throws<InvalidOperationException>(() =>
            {
                delay.Play();
                delay.Play();
            });
        }

        [Test]
        public void WeaponCanNotShootWhileDelayPlaying()
        {
            var weapon = new WeaponWithDelay(new DummyWeapon(), new WeaponDelay(new TimerWithCanceling(new Timer(1))));

            weapon.Enable();
            weapon.Shoot();

            Assert.False(weapon.CanShoot);
        }
    }
}