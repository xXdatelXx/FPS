using FPS.Model;
using FPS.Tools;
using NUnit.Framework;
using UnityEngine;

namespace FPS.Tests
{
    internal sealed class RecoilTest
    {
        [Test]
        public void RecoilCurveWorkCorrectly()
        {
            var recoil = CreateRecoil(Vector2.one).Next();

            Assert.AreEqual(recoil, Vector2.one);
        }

        private IRecoil CreateRecoil(Vector2 key)
        {
            var magazine = new Magazine(1);
            var unityCurve = new AnimationCurve();
            unityCurve.AddKey(1, 1);
            var curve = new Curve(unityCurve);
            var weaponDelay = new WeaponDelay(new Timer(1));

            return new CurveRecoil(curve, weaponDelay, magazine);
        }
    }
}