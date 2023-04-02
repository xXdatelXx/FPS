namespace FPS.Tools
{
    public interface IRay
    {
        bool Cast(out IRayHit hit);
    }
}