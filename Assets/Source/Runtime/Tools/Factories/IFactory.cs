namespace Source.Runtime.Tools.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}