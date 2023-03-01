namespace FPS.Model
{
    public interface IHealth
    {
        bool Died { get; }
        void TakeDamage(float damage);
    }
}