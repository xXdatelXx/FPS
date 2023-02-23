namespace Source.Runtime.Tools.Ray
{
    public interface IRay<TTarget>
    {
        bool Cast(out IRayData<TTarget> data);
    }
}