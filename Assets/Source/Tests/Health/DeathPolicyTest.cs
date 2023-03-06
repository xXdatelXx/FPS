using FPS.Model;
using NUnit.Framework;

namespace FPS.Tests
{
    public sealed class DeathPolicyTest
    {
        [Test]
        public void DeathPolicyWorkCorrectly()
        {
            var policy = new DeathPolicy();
            
            Assert.AreEqual(policy.Died(-1), true);
        }
    }
}