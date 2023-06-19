namespace FPS.GamePlay
{
    public interface IWeaponView
    {
        void Shoot();
        void Reload();
        void Equip();
        void UneQuip();
        void VisualizeBullets(int bullets);
    }
}