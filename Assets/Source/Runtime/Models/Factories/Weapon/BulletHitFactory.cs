using FPS.Model;
using FPS.Tools;
using UnityEngine;

namespace Source.Runtime.Models.Factories.Weapon
{
    public sealed class BulletHitFactory : MonoBehaviour, IFactory<IBulletHitView>
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private IRandom<int> _random;

        private void Awake() => 
            _random = new IntRandom(new Range(0, _sprites.Length));

        public IBulletHitView Create()
        {
            var transform = Instantiate(_transform);
            var particle = new BulletParticle(_particle);
            var sprite = new UnitySpite(_spriteRenderer, _sprites[_random.Next()]);
            var movement = new GameObjectWithMovement(transform);
            var rotation = new GameObjectWithRotation(transform);
            
            return new BulletHitView(particle, sprite, movement, rotation);
        }
    }
}