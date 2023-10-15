using System;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class Magazine : IMagazine
    {
        private IntWithStandard _bullets;
        private readonly IMagazineView _view;

        public Magazine(int bulletCount, IMagazineView view)
        {
            _bullets = new IntWithStandard(bulletCount.ThrowExceptionIfValueSubZero(nameof(bulletCount)));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public Magazine(int bulletCount) : this(bulletCount, new NullMagazineView())
        { }

        public int Bullets => _bullets.Value;
        public bool CanGet => _bullets > 0;
        public bool CanReload => !_bullets.StandardEqualsValue;

        public void Get()
        {
            if (!CanGet)
                throw new InvalidOperationException(nameof(Get));

            _bullets--;
            _view.GetBullet(_bullets.Value);
        }

        public void Reload()
        {
            if (!CanReload)
                throw new InvalidOperationException(nameof(Reload));

            _bullets.Reset();
            _view.Reload(_bullets.Value);
        }
    }
}