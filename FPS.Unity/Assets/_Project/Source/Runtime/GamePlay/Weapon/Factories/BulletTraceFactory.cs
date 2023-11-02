using FPS.GamePlay;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class BulletTraceFactory : MonoBehaviour, IFactory<IBulletTrace>
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private RaySpawnPoint _spawnPoint;
        [SerializeField] private float _raySpeed;
        [SerializeField] private float _standardMotion;
        [SerializeField] private Transform _parent;
        [SerializeField, Range(0, 100)] private int _percentToCreate;

        private void OnValidate() => _parent ??= transform;

        public IBulletTrace Create()
        {
            var prefab = Instantiate(_prefab, _spawnPoint.transform.position, Quaternion.identity, _parent);
            var movement = new DoTweenMovement(prefab, _raySpeed);
            var randomToCastTrace = new BoolRandom(new PercentChance(_percentToCreate));
            var ray = new BulletTrace(movement, new Position(_spawnPoint.transform), _standardMotion);

            return new RandomBulletTrace(ray, randomToCastTrace);
        }
    }
}