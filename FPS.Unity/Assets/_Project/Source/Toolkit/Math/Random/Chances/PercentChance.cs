using System;

namespace FPS.Toolkit
{
    public sealed class PercentChance : IChance
    {
        private readonly int _luckChance;
        private readonly Random _random = new();

        public PercentChance(int luckChance) =>
            _luckChance = luckChance.ThrowExceptionIfValueSubZero(nameof(luckChance));

        public bool TryLuck() => _random.Next(0, 100) <= _luckChance;
    }
}