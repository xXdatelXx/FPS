using System;

namespace FPS.Toolkit
{
    [Serializable]
    public sealed class SubOrEqualZeroException : Exception
    {
        public SubOrEqualZeroException(string message) : base($"{message} <= 0")
        {
        }
    }
}