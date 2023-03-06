﻿using Cysharp.Threading.Tasks;
using FPS.Game;
using NUnit.Framework;

namespace FPS.Tests
{
    public sealed class GameLoopTest
    {
        private readonly IGameLoop _loop;
        private readonly TickMarker _marker;

        public GameLoopTest()
        {
            _loop = new GameLoop(new GameTime());
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
            Assert.AreEqual(_marker.WasTick, true);
        }

        [Test]
        public async void CorrectlyDeltaTime()
        {
            await UniTask.Yield();
            Assert.AreEqual(_marker.DeltaTime > 0, true);   
        }
    }
}