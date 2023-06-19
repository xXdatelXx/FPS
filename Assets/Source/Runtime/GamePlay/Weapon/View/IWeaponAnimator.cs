namespace FPS.GamePlay
{
    public interface IWeaponAnimator
    {
        void PlayShoot();
        void PlayReload();
        void PlayEnable();
        void PlayDisable();
    }
}