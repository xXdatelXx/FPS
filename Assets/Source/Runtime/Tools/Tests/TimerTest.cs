using System;
using NUnit.Framework;

namespace FPS.Tools.Tests
{
    public sealed class TimerTest
    {
        [Test]
        public async void WorkCorrectly()
        {
            var time = 3;
            var timer = new Timer(time);
            var oldTime = DateTime.Now;

            timer.Play();
            await timer.End();
            var workTime = DateTime.Now - oldTime;

            Assert.AreEqual(workTime.Seconds, time);
        }
    }
}