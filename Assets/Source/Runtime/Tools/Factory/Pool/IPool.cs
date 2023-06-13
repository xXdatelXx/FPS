namespace FPS.Tools
{
    public interface IPool<TItem>
    {
        bool Contains(TItem obj);
        TItem Get();
        void Return(TItem obj);
    }
}