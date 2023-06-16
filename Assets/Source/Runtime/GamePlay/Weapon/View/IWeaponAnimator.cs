namespace FPS.Model
{
    public interface IWeaponAnimator
    {
        void PlayShoot();
        void PlayReload();
        void PlayEnable();
        void PlayDisable();
    }
}