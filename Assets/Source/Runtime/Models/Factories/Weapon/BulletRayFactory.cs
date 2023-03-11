using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRayFactory : MonoBehaviour, IFactory<IBulletRay>
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private RaySpawnPoint _spawnPoint;
        [SerializeField] private float _rayWorkTime = 1;
        [SerializeField] private float _raySpeed;
        [SerializeField] private Vector3 _standardMotion;

        public IBulletRay Create()
        {
            var transform = Instantiate(_transform, _spawnPoint.transform);
            var workTimer = new Timer(_rayWorkTime);
            var movement = new GameObjectWithDoTweenMovement(transform, _raySpeed);
            var standardMotion = transform.TransformDirection(_standardMotion);
            
            var ray = new BulletRay(workTimer, movement, standardMotion);

            return new RandomBulletRay(ray, new BoolRandom(new PercentChance(20)));
        }
    }
}