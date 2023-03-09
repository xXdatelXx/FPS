namespace FPS.Tools
{
    public interface IRandom<out T>
    {
        T Next();
    }
}