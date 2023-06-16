namespace FPS.Model
{
    public interface IHealth : IReadOnlyHealth
    {
        void TakeDamage(float damage);
    }
}