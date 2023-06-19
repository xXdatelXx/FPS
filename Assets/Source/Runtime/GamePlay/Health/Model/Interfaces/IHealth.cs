namespace FPS.GamePlay
{
    public interface IHealth : IReadOnlyHealth
    {
        void TakeDamage(float damage);
    }
}