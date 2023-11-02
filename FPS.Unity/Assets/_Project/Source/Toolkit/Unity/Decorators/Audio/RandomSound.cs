using System.Collections.Generic;
using System.Linq;

namespace FPS.Toolkit
{
    public sealed class RandomSound : ISound
    {
        private readonly IEnumerable<ISound> _sounds;

        public RandomSound(IEnumerable<ISound> sounds) =>
            _sounds = sounds.TryThrowNullReferenceForeach(nameof(sounds));

        public RandomSound(params ISound[] sounds) : this(sounds.ToList())
        { }

        public void Play() =>
            _sounds.RandomElement().Play();
    }
}