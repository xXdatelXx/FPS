using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletSleeve : IBulletSleeve
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _force;
        private readonly Vector3 _direction;
        private readonly Vector3 _throwPosition;

        public BulletSleeve(Rigidbody rigidbody, float force, Vector3 direction)
        {
            _rigidbody = rigidbody.ThrowExceptionIfArgumentNull(nameof(rigidbody));
            _force = force.ThrowExceptionIfValueSubZero(nameof(force));
            _direction = direction;
            _throwPosition = _rigidbody.transform.localPosition;
        }

        public void Throw()
        {
            _rigidbody.gameObject.SetActive(true);
            _rigidbody.transform.localPosition = _throwPosition;
            _rigidbody.AddRelativeForce(_direction * _force);
        }

        public void Hide() => 
            _rigidbody.gameObject.SetActive(false);
    }
}