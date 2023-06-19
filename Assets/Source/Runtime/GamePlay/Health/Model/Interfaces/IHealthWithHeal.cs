namespace FPS.GamePlay
{
    public interface IHealthWithHeal : IHealth
    {
        bool CanHeal { get; }
        void Heal(float heal);
    }
}