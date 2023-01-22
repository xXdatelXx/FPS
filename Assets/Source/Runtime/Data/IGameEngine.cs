namespace Source.Runtime.CompositeRoot
{
    public interface IGameEngine
    {
        IPlayerFactory PlayerFactory { get; }
    }
}