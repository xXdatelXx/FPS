namespace Source.Runtime.Models.Game.Loop.Tickables
{
    public interface ITickable
    {
        void Tick(float deltaTime);
    }
}