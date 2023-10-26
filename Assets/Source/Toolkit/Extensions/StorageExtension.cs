using FPS.Toolkit.Storage;

namespace FPS.Toolkit
{
    public static class StorageExtension
    {
        public static bool NullOrDefault<T>(this IStorage<T> storage) =>
            !storage.Exists || storage.Load().Equals(default(T));

        public static T LoadOrDefault<T>(this IStorage<T> storage) =>
            storage.Exists ? storage.Load() : default;
    }
}