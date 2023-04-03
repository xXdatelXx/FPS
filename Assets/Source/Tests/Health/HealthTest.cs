using System;
using FPS.Model;
using FPS.Tools;
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
            Assert.Throws<ArgumentOutOfRangeException>(() => new Health(1).TakeDamage(-1));

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
    }
}