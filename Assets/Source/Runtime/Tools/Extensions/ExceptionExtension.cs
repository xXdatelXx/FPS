using System;

namespace FPS.Tools
{
    public static class ExceptionExtension
    {
        public static T ThrowExceptionIfNull<T>(this T value, string name = "value") =>
            value ?? throw new NullReferenceException(name);

        public static T ThrowExceptionIfArgumentNull<T>(this T value, string name = "value") =>
            value ?? throw new ArgumentNullException(name);

        public static dynamic ThrowExceptionIfValueSubZero(this IComparable value, string name = "value") =>
            (dynamic)value < 0 ? throw new SubZeroException(name) : value;

        public static dynamic ThrowExceptionIfValueSubOrEqualZero(this IComparable value, string name = "value") =>
            (dynamic)value <= 0 ? throw new SubOrEqualZeroException(name) : value;
    }
}