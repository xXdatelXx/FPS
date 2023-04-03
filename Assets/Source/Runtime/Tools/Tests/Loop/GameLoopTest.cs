using Cysharp.Threading.Tasks;
using FPS.Tools.GameLoop;
using NUnit.Framework;

namespace FPS.Tools.Tests
{
    internal sealed class GameLoopTest
    {
        private readonly IGameLoop _loop;
        private readonly TickMarker _marker;

        public GameLoopTest()
        {
            _loop = new GameLoop.GameLoop(new GameTime());
            _marker = new TickMarker();
        }

        [SetUp]
        public void SetUp()
        {
            _loop.Add(_marker);
            _loop.Start();
        }

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