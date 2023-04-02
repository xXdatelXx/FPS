using System;
using FPS.Model;
using NUnit.Framework;

namespace FPS.Tests
{
    public sealed class HealthTest
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
            Assert.Throws<Exception>(() => new Health(1).TakeDamage(-1));

        [Test]
        public void CanNotDamageCorpse()
        {
            Assert.Throws<Exception>(() =>
            {
                var health = new Health(1);

                health.TakeDamage(1);
                health.TakeDamage(1);
            });
        }

        [Test]
        public void CanNotCreateCorpse() =>
            Assert.Throws<Exception>(() => new Health(-1));
    }
}