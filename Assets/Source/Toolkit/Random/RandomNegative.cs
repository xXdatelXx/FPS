using System;

namespace FPS.Toolkit
{
    public sealed class RandomNegative<T> : IRandom<T> where T : IComparable
    {
        private readonly IRandom<T> _random;
        private readonly IRandom<bool> _negate;

        public RandomNegative(IRandom<T> random, IRandom<bool> negate)
        {
            _random = random.ThrowExceptionIfArgumentNull(nameof(random));
            _negate = negate.ThrowExceptionIfArgumentNull(nameof(negate));
        }

        public T Next()
        {
            var next = _random.Next();

            if (_negate.Next())
            {
                dynamic negativeOne = -1;
                next *= negativeOne;
            }

            return next;
        }
    }
}