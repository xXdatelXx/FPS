namespace FPS.Toolkit
{
    public interface IRandom<out T>
    {
        T Next();
    }
}