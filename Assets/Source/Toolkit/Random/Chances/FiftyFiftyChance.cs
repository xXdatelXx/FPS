using System;

namespace FPS.Toolkit
{
    public sealed class FiftyFiftyChance : IChance
    {
        private readonly Random _random;
        public bool TryLuck() => _random.Next(0, 2) == 0;
    }
}