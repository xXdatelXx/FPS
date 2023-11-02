using System;

namespace FPS.Toolkit
{
    public static class NumberExceptionExtension
    {
        public static dynamic ThrowExceptionIfValueSubZero(this IComparable value, string name) =>
            (dynamic)value < 0 ? throw new SubZeroException(name) : value;

        public static dynamic ThrowExceptionIfValueSubOrEqualZero(this IComparable value, string name) =>
            (dynamic)value <= 0 ? throw new SubOrEqualZeroException(name) : value;
    }
}