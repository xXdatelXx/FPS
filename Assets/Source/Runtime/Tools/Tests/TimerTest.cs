using System;
using NUnit.Framework;

namespace FPS.Tools.Tests
{
    internal sealed class TimerTest
    {
        [Test]
        public async void AsyncTimerWorkCorrectly()
        {
            const int time = 3;
            var timer = new AsyncTimer(time);
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