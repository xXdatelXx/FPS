namespace Source.Runtime.Models.Game.Loop.Tickables
{
    public interface IFixedTickable
    {
        void FixedTick(float deltaTime);
    }
}