using System;

namespace FPS.Tools
{
    public readonly struct FiftyFiftyChance : IChance
    {
        private readonly Random _random;
        public bool TryLuck() => _random.Next(0, 2) == 0;
    }
}