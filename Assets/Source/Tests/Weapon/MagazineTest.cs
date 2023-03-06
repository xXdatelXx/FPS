﻿using System;
using FPS.Model;
using NUnit.Framework;

namespace FPS.Tests
{
    public sealed class MagazineTest
    {
        [Test]
        public void CanNotGetBulletInEmptyMagazine()
        {
            var magazine = new Magazine(1);

            magazine.Get();

            Assert.AreEqual(magazine.CanGet, false);
        }
        
        [Test]
        public void ThrowExceptionIfTakeFromEmptyMagazine()
        {
            var wasException = false;

            try
            {
                new Magazine(0).Get();
            }
            catch (Exception e)
            {
                wasException = true;
            }


            Assert.AreEqual(wasException, true);
        }

        [Test]
        public void ResetWorkCorrectly()
        {
            var magazine = new Magazine(1);
            
            magazine.Get();
            magazine.Reset();
            
            Assert.AreEqual(magazine.Bullets, 1);
        }
    }
}