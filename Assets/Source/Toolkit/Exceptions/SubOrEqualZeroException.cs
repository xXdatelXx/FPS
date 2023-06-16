using System;

namespace FPS.Toolkit
{
    public sealed class SubOrEqualZeroException : Exception
    {
        public SubOrEqualZeroException(string message) : base($"{message} <= 0")
        {
        }
    }
}