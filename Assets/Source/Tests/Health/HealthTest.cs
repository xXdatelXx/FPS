using System;
using FPS.GamePlay;
using FPS.Toolkit;
using NUnit.Framework;

namespace FPS.Tests
{
    internal sealed class HealthTest
    {
        [Test]
        public void DieCorrectly()
        {
            var health = new Health(1);

            health.TakeDamage(1);

            Assert.True(health.Died);
        }

        [Test]
        public void CanNotHealByDamage() =>
            Assert.Throws<SubZeroException>(() => new Health(1).TakeDamage(-1));

        [Test]
        public void CanNotDamageCorpse()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var health = new Health(1);

                health.TakeDamage(1);
                health.TakeDamage(1);
            });
        }

        [Test]
        public void CanNotCreateCorpse() =>
            Assert.Throws<SubOrEqualZeroException>(() => new Health(-1));

        [Test]
        public void AutoHealWorkCorrectly()
        {
            var health = new Health(2);
            var heal = new AutoHeal(health, 1);

            health.TakeDamage(1);
            heal.Tick(0);

            Assert.That(health.Points == 2);
        }

        [Test]
        public void CanNotHealMoreThanMaxHealth()
        {
            var maxHealth = 2;
            var health = new Health(maxHealth);

            Assert.Throws<InvalidOperationException>(() => health.Heal(1));
        }
    }
}