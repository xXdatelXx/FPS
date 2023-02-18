namespace Source.Runtime.Models.Weapon.Views
{
    public interface IWeaponView
    {
        void OnShoot();
        void OnReload();
        void OnEnable();
        void OnDisable();
        void VisualizeBullets(int bullets);
    }
}