using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletHitFactory : MonoBehaviour, IFactory<IBulletHitView>
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Sprite[] _sprites;
        private IRandom<int> _random;

        private void Awake() =>
            _random = new IntRandom(new Range(0, _sprites.Length));

        public IBulletHitView Create()
        {
            var prefab = Instantiate(_particle, parent: transform);
            var prefabSpriteRenderer = prefab.gameObject.AddComponent<SpriteRenderer>();
            var particle = new BulletParticle(prefab);
            var sprite = new UnitySpite(new UnitySpriteRenderer(prefabSpriteRenderer), _sprites[_random.Next()]);
            var movement = new GameObjectWithMovement(prefab.transform);
            var rotation = new GameObjectWithRotation(prefab.transform);

            return new BulletHitView(particle, sprite, movement, rotation);
        }
    }
}