namespace FPS.Model
{
    public interface IWeaponView
    {
        void Shoot();
        void Reload();
        void Enable();
        void Disable();
        void VisualizeBullets(int bullets);
    }
}