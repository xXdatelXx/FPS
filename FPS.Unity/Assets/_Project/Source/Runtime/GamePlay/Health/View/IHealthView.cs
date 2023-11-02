namespace FPS.GamePlay
{
    public interface IHealthView
    {
        void Damage(float health);
        void Heal(float health);
        void Die();
    }
}