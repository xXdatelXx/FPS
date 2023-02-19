namespace Source.Runtime.Models.Weapons.Views
{
    public interface IWeaponAnimator
    {
        void PlayShoot();
        void PlayReload();
        void PlayEnable();
        void PlayDisable();
    }
}