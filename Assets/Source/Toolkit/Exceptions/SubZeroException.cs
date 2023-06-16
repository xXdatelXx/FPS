using System;

namespace FPS.Toolkit
{
    public sealed class SubZeroException : Exception
    {
        public SubZeroException(string message) : base($"{message} < 0")
        {
        }
    }
}