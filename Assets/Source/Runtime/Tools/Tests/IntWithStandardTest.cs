using NUnit.Framework;

namespace FPS.Tools.Tests
{
    public sealed class IntWithStandardTest
    {
        [Test]
        public void ResetWorkCorrectly()
        {
            var value = new IntWithStandard(5);

            value--;
            value.Reset();

            Assert.AreEqual(value.Value, 5);
        }
    }
}