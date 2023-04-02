using System;

namespace FPS.Tools
{
    public sealed class SubZeroException : Exception
    {
        public SubZeroException(string message) : base($"{message} < 0")
        {
        }
    }
}