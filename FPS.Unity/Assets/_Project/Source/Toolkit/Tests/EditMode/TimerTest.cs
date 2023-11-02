using System;
using FPS.Toolkit.GameLoop;
using NUnit.Framework;

namespace FPS.Toolkit.Tests
{
    internal sealed class TimerTest
    {
        [Test]
        public async void AsyncTimerWorkCorrectly()
        {
            const int time = 3;
            var timer = new Timer(time);
            new GameLoop.GameLoop(new PhysicGameTime(), timer).Start();
            var oldTime = DateTime.Now;

            timer.Play();
            await timer.End();
            var workTime = DateTime.Now - oldTime;

            Assert.AreEqual(workTime.Seconds, time);
        }

        [Test]
        public void TickTimerWorkCorrectly()
        {
            const int time = 1;
            var timer = new Timer(time);

            timer.Play();
            timer.Tick(time);

            Assert.That(!timer.Playing);
        }
    }
}