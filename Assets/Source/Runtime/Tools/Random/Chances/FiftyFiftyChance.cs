using System;

namespace FPS.Tools
{
    public sealed class FiftyFiftyChance : IChance
    {
        private readonly Random _random;
        public bool TryLuck() => _random.Next(0, 2) == 0;
    }
}