using System;

namespace FPS.Toolkit
{
    public static class NullExceptionExtension
    {
        //Not ?? because unity
        public static T ThrowExceptionIfNull<T>(this T value, string name)
        {
            if ((dynamic)value == null)
                throw new NullReferenceException(name);

            return value;
        }

        public static T ThrowExceptionIfArgumentNull<T>(this T value, string name)
        {
            if ((dynamic)value == null)
                throw new ArgumentNullException(name);

            return value;
        }
    }
}