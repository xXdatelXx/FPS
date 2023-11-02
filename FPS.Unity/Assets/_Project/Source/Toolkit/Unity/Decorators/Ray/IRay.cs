namespace FPS.Toolkit
{
    public interface IRay<TTarget>
    {
        bool Cast(out RayHit<TTarget> hit);
    }
}