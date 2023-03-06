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

            Assert.AreEqual(health.Died, true);
        }

        [Test]
        public void CanNotHeal()
        {
            var health = new Health(1);
            var wasException = false;

            try
            {
                health.TakeDamage(-1);
            }
            catch (Exception e)
            {
                wasException = true;
            }

            Assert.AreEqual(wasException, true);
        }

        [Test]
        public void CanNotDamageCorpse()
        {
            var health = new Health(1);
            var wasException = false;

            try
            {
                health.TakeDamage(1);
                health.TakeDamage(1);
            }
            catch (Exception e)
            {
                wasException = true;
            }

            Assert.AreEqual(wasException, true);
        }

        [Test]
        public void CanNotCreateCorpse()
        {
            var wasException = false;

            try
            {
                new Health(-1);
            }
            catch (Exception e)
            {
                wasException = true;
            }

            Assert.AreEqual(wasException, true);
        }
    }
}