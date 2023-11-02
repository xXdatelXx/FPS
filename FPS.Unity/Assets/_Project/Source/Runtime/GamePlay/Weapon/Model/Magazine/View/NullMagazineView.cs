namespace FPS.GamePlay
{
    public sealed class NullMagazineView : IMagazineView
    {
        public void GetBullet(int bulletsCount)
        { }

        public void Reload(int bulletsCount)
        { }
    }
}