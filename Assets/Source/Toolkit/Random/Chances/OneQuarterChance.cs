﻿using System;

namespace FPS.Toolkit
{
    public sealed class OneQuarterChance
    {
        private readonly Random _random = new();
        public bool TryLuck() => _random.Next(0, 4) == 0;
    }
}