namespace Source.Runtime.Models.Factory
{
    public interface IFactory<out T>
    {
        T Create();
    }
}