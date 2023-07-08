    using System;

namespace FPS.Toolkit
{
    public sealed class RandomNegative<T> : IRandom<T> where T : IComparable
    {
        private readonly IRandom<T> _random;
        private readonly IChance _negateChance;

        public RandomNegative(IRandom<T> random, IChance negateChance)
        {
            _random = random.ThrowExceptionIfArgumentNull(nameof(random));
            _negateChance = negateChance.ThrowExceptionIfArgumentNull(nameof(negateChance));
        }

        public T Next()
        {
            var next = _random.Next();

            if (_negateChance.TryLuck())
            {
                dynamic negativeOne = -1;
                next *= negativeOne;
            }

            return next;
        }
    }
}