using FPS.Tools;
using Sirenix.Utilities;

namespace FPS.Model
{
    public sealed class BulletHitSprites : IBulletHitSprites
    {
        private readonly ISpite[] _spites;
        private readonly IRandom<int> _random;
        private ISpite _activeSprite;
        
        public BulletHitSprites(ISpite[] spites)
        {
            _spites = spites.ThrowExceptionIfArgumentNull(nameof(spites));
            spites.ForEach(i => i.ThrowExceptionIfArgumentNull(nameof(spites)));
            _random = new IntRandom(0, _spites.Length);
        }

        public void Update()
        {
            _activeSprite?.Hide();
            _activeSprite = _spites[_random.Next()];
            _activeSprite.Render();
        }
    }
}