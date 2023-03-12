using FPS.Model;
using FPS.Tools;
using UnityEngine;

namespace Source.Runtime.Models.Factories.Weapon
{
    public sealed class BulletHitFactory : MonoBehaviour, IFactory<IBulletHitView>
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Sprite[] _sprites;
        private IRandom<int> _random;

        private void Awake() =>
            _random = new IntRandom(new Range(0, _sprites.Length));

        public IBulletHitView Create()
        {
            var prefab = Instantiate(_prefab);
            var prefabSpriteRenderer = prefab.gameObject.AddComponent<SpriteRenderer>();
            var prefabParticle = prefab.gameObject.AddComponent<ParticleSystem>();
            prefabParticle = _particle;
            var particle = new BulletParticle(prefabParticle);
            var sprite = new UnitySpite(new UnitySpriteRenderer(prefabSpriteRenderer), _sprites[_random.Next()]);
            var movement = new GameObjectWithMovement(prefab);
            var rotation = new GameObjectWithRotation(prefab);

            return new BulletHitView(particle, sprite, movement, rotation);
        }
    }
}