using UnityEngine;

namespace FPS.Tools
{
    public readonly struct PercentChance : IChance
    {
        private readonly int _luckChance;

        public PercentChance(int luckChance) =>
            _luckChance = luckChance.ThrowExceptionIfValueSubZero(nameof(luckChance));

        public bool TryLuck() => Random.Range(0, 100) <= _luckChance;
    }
}