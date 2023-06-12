namespace FPS.Model
{
    public interface IHealthWithHeal : IHealth
    {
        bool CanHeal { get; }
        void Heal(float heal);   
    }
}