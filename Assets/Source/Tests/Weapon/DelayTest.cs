using System;
using FPS.Model;
using FPS.Tools;
using NUnit.Framework;
using UnityEngine;

namespace FPS.Tests
{
    public sealed class DelayTest
    {
        [Test]
        public void CanNotCreateDoubleDelay()
        {
            var wasException = false;

            try
            {
                var delay = new WeaponDelay(new Timer(1));
                
                delay.Play();
                delay.Play();
            }
            catch (Exception e)
            {
                wasException = true;
            }
            
            Assert.True(wasException);
        }
    }
}