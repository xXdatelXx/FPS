using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRayFactory : MonoBehaviour, IFactory<IBulletRay>
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private RaySpawnPoint _spawnPoint;
        [SerializeField] private float _raySpeed;
        [SerializeField] private Vector3 _standardMotion;
        [SerializeField] private Transform _parent;
        [SerializeField, Range(0, 100)] private int _percentToCreate = 20;

        private void OnValidate() => _parent ??= transform;

        public IBulletRay Create()
        {
            var prefab = Instantiate(_prefab, _spawnPoint.transform.position, Quaternion.identity, _parent);

            var movement = new GameObjectWithDoTweenMovement(prefab, _raySpeed);
            var standardMotion = prefab.TransformDirection(_standardMotion);
            var gameObject = new Tools.GameObject(prefab.gameObject);

            var ray = new BulletRay(movement, standardMotion, new Position(_spawnPoint.transform), gameObject);

            return new RandomBulletRay(ray, new BoolRandom(new PercentChance(_percentToCreate)));
        }
    }
}