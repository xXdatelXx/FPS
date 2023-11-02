using System;

namespace FPS.Toolkit
{
    public sealed class OneQuarterChance : IChance
    {
        private readonly Random _random = new();
        public bool TryLuck() => _random.Next(0, 4) == 0;
    }
}