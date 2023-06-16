using System;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class Magazine : IMagazine
    {
        private IntWithStandard _bullets;

        public Magazine(int bulletCount) =>
            _bullets = new IntWithStandard(bulletCount.ThrowExceptionIfValueSubZero(nameof(bulletCount)));

        public int Bullets => _bullets.Value;
        public bool CanGet => _bullets > 0;
        public bool CanReset => !_bullets.StandardEqualsValue;

        public void Get()
        {
            if (!CanGet)
                throw new InvalidOperationException(nameof(Get));

            _bullets--;
        }

        public void Reset()
        {
            if (!CanReset)
                throw new InvalidOperationException(nameof(Reset));

            _bullets.Reset();
        }
    }
}