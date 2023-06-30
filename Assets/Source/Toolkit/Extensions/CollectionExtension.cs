using System.Collections.Generic;
using System.Linq;

namespace FPS.Toolkit
{
    public static class CollectionExtension
    {
        public static bool Has<T>(this IEnumerable<T> list, T item) =>
            list.Any(i => i.Equals(item));

        public static IEnumerable<T> TryThrowNullReferenceForeach<T>(this IEnumerable<T> enumerable, string name) =>
            enumerable.Select(i => i.ThrowExceptionIfNull(name));
        
        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            var array = enumerable as T[] ?? enumerable.ToArray();
            var index = new NumberRandom(0, array.Length).Next();
            
            return array.ElementAt(index);
        }
    }
}