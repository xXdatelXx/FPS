using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class MagazineView : IMagazineView
    {
        private readonly IText _text;

        public MagazineView(IText text) =>
            _text = text.ThrowExceptionIfArgumentNull(nameof(text));
        
        public void GetBullet(int bulletsCount) => 
            _text.Visualize(bulletsCount);

        public void Reload(int bulletsCount) => 
            _text.Visualize(bulletsCount);
    }
}