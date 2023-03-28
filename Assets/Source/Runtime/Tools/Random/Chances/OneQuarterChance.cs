using System;

namespace FPS.Tools
{
    public readonly struct OneQuarterChance
    {
        private readonly Random _random;

        public bool TryLuck() => _random.Next(0, 4) == 0;
    }
}