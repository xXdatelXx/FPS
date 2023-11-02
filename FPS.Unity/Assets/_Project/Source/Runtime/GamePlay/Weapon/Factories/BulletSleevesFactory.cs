using FPS.GamePlay;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class BulletSleevesFactory : MonoBehaviour, IFactory<IBulletSleeve>
    {
        [SerializeField] private Rigidbody _prefab;
        [SerializeField] private float _throwForce;
        [SerializeField] private Vector3 _throwDirection;
        [SerializeField] private Transform _parent;

        public IBulletSleeve Create()
        {
            var instance = Instantiate(_prefab, transform.position, transform.rotation, _parent);
            var sleeve = new BulletSleeve(instance, _throwForce, _throwDirection);
            return sleeve;
        }
    }
}