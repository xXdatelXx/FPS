using System;

namespace Source.Runtime.Tools.Exceptions
{
    public sealed class SubZeroException : Exception
    {
        public SubZeroException(string message) : base($"{message} < 0")
        {
        }
    }
}