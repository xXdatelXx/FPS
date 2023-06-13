using System.Collections.Generic;
using System.Linq;

namespace FPS.Tools
{
    public static class CollectionExtension
    {
        public static bool Has<T>(this IEnumerable<T> list, T item) =>
            list.Any(i => i.Equals(item));

        public static IEnumerable<T> TryThrowNullReferenceForeach<T>(this IEnumerable<T> enumerable, string name) =>
            enumerable.Select(i => i.ThrowExceptionIfNull(name));
    }
}