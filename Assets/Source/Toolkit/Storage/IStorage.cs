namespace FPS.Toolkit.Storage
{
    public interface IStorage<TValue>
    {
        bool Exists { get; }
        
        TValue Load();
        void Save(TValue value);
    }
}