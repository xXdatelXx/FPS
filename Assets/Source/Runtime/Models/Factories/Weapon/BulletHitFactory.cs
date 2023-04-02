using FPS.Model;
using FPS.Tools;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class BulletHitFactory : MonoBehaviour, IFactory<IBulletHitView>
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Transform _parent;

        private void OnValidate() => _parent ??= transform;

        public IBulletHitView Create()
        {
            var prefab = Instantiate(_particle, _parent);
            var particle = new BulletParticle(prefab);
            var movement = new Movement(prefab.transform);

            return new BulletHitView(movement, particle);
        }
    }
}