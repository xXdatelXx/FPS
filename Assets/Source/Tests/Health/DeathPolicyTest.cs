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

            Assert.True(policy.Died(-1));
        }
    }
}