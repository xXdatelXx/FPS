using System;

namespace FPS.Tools
{
    public static class NullExceptionExtension
    {
        public static T ThrowExceptionIfNull<T>(this T value, string name) =>
            value ?? throw new NullReferenceException(name);

        public static T ThrowExceptionIfArgumentNull<T>(this T value, string name) =>
            value ?? throw new ArgumentNullException(name);
    }
}