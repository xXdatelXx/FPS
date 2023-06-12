using System;

namespace FPS.Tools
{
    public sealed class OneQuarterChance
    {
        private readonly Random _random;
        public bool TryLuck() => _random.Next(0, 4) == 0;
    }
}