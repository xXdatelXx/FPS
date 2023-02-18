using System;
using Source.Runtime.Tools.Extensions;
using Source.Runtime.Tools.Math;

namespace FPS.Model.Weapons.Bullet
{
    public sealed class Magazine : IMagazine
    {
        public Magazine(int bulletCount) => 
            Bullets = new IntWithStandard(bulletCount.ThrowExceptionIfValueSubZero(nameof(bulletCount)));

        public IntWithStandard Bullets { get; private set; }
        public bool CanGet => Bullets > 0;
        public bool CanReset => !Bullets.StandardEqualsValue;

        public void Get()
        {
            if (!CanGet)
                throw new InvalidOperationException(nameof(Get));

            Bullets--;
        }

        public void Reset()
        {
            if (!CanReset)
                throw new InvalidOperationException(nameof(Reset));

            Bullets.Reset();
        }
    }
}