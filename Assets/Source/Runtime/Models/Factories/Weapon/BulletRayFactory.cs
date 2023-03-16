using FPS.Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace FPS.Model
{
    public sealed class BulletRayFactory : MonoBehaviour, IFactory<IBulletRay>
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private RaySpawnPoint _spawnPoint;
        [SerializeField] private float _raySpeed;
        [SerializeField] private Vector3 _standardMotion;

        public IBulletRay Create()
        {
            var prefab = Instantiate(_prefab, _spawnPoint.transform.position, Quaternion.identity, transform);

            var movement = new GameObjectWithDoTweenMovement(prefab, _raySpeed);
            var standardMotion = prefab.TransformDirection(_standardMotion);

            var ray = new BulletRay(movement, standardMotion);

            return new RandomBulletRay(ray, new BoolRandom(new PercentChance(20)));
        }
    }
}