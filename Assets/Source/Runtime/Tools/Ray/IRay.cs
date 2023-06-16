namespace FPS.Tools
{
    public interface IRay<TTarget>
    {
        bool Cast(out RayHit<TTarget> hit);
    }
}