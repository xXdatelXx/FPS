using Cysharp.Threading.Tasks;
using FPS.Toolkit.GameLoop;
using NUnit.Framework;

namespace FPS.Toolkit.Tests
{
    internal sealed class GameLoopTest
    {
        private readonly IGameLoop _loop;
        private readonly TickMarker _marker;

        public GameLoopTest()
        {
            _marker = new TickMarker();
            _loop = new GameLoop.GameLoop(new PhysicGameTime(), _marker);
        }

        [SetUp]
        public void SetUp() => _loop.Start();

        [Test]
        public async void TickingCorrectly()
        {
            await UniTask.Yield();
            Assert.True(_marker.WasTick);
        }

        [Test]
        public async void CorrectlyDeltaTime()
        {
            await UniTask.Yield();
            Assert.True(_marker.DeltaTime > 0);
        }
    }
}