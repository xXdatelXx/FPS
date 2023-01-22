namespace Source.Runtime.TickSystem
{
    public interface IFixedTickable
    {
        void FixedTick(float deltaTime);
    }
}