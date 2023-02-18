namespace Source.Runtime.Models.Weapon.Views
{
    public interface IWeaponAnimator
    {
        void PlayShoot();
        void PlayReload();
        void PlayEnable();
        void PlayDisable();
    }
}