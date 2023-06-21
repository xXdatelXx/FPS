using FPS.GamePlay;
using FPS.Toolkit;
using UnityEngine;
using GameObject = FPS.Toolkit.GameObject;

namespace FPS.Factories
{
    public sealed class BulletTraceFactory : MonoBehaviour, IFactory<IBulletTrace>
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private RaySpawnPoint _spawnPoint;
        [SerializeField] private float _raySpeed;
        [SerializeField] private Vector3 _standardMotion;
        [SerializeField] private Transform _parent;
        [SerializeField, Range(0, 100)] private int _percentToCreate = 20;

        private void OnValidate() => _parent ??= transform;

        public IBulletTrace Create()
        {
            var prefab = Instantiate(_prefab, _spawnPoint.transform.position, Quaternion.identity, _parent);

            var movement = new MovementWithTeleport(new Position(prefab), new DoTweenMovement(prefab, _raySpeed));
            var standardMotion = prefab.TransformDirection(_standardMotion);
            var gameObject = new GameObject(prefab.gameObject);

            var ray = new BulletTrace(movement, gameObject, new Position(_spawnPoint.transform), standardMotion);

            return new RandomBulletTrace(ray, new BoolRandom(new PercentChance(_percentToCreate)));
        }
    }
}