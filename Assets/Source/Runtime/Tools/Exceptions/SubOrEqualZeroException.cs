using System;

namespace FPS.Tools
{
    public sealed class SubOrEqualZeroException : Exception
    {
        public SubOrEqualZeroException(string message) : base($"{message} <= 0")
        {
        }
    }
}