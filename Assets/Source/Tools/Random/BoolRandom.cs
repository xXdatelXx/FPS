namespace FPS.Tools
{
    public sealed class BoolRandom : IRandom<bool>
    {
        private readonly IChance _chance;

        public BoolRandom(IChance chance) =>
            _chance = chance.ThrowExceptionIfArgumentNull(nameof(chance));

        public bool Next() => _chance.TryLuck();
    }
}