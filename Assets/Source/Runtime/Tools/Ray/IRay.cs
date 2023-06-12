namespace FPS.Tools
{
    public interface IRay<TTarget>
    {
        void Cast(out RayHit<TTarget> hit);
    }
}