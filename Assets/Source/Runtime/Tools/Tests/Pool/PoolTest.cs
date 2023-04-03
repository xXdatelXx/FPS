using System;
using NUnit.Framework;

namespace FPS.Tools.Tests
{
    internal sealed class PoolTest
    {
        [Test]
        public void ReturningCorrectly()
        {
            var pool = new Pool<DummyObject>(new DummyFactory());

            var obj = pool.Get();
            pool.Return(obj);

            Assert.True(pool.Contains(obj));
        }

        [Test]
        public void CreatingOnGetInEmptyStack()
        {
            var factory = new DummyFactory();
            var pool = new Pool<DummyObject>(factory);

            pool.Get();

            Assert.True(factory.Created);
        }

        [Test]
        public void GettingCorrectly()
        {
            var pool = new Pool<DummyObject>(new DummyFactory());
            var obj = pool.Get();

            pool.Return(obj);

            Assert.True(pool.Get() == obj);
        }

        [Test]
        public void DoNotCanReturnDuplicate()
        {
            var pool = new Pool<DummyObject>(new DummyFactory());
            var obj = pool.Get();

            Assert.Throws<InvalidOperationException>(() =>
            {
                pool.Return(obj);
                pool.Return(obj);
            });
        }
    }
}