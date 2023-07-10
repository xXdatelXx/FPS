using FPS.Toolkit;
using UnityEngine;
using static FPS.Toolkit.BehaviourNodeStatus;

namespace FPS.GamePlay
{
    [RequireComponent(typeof(Collider))]
    public abstract class Enemy : MonoBehaviour, IHealth
    {
        private IHealth _health;
        private IBehaviourNode _behaviourTree;

        public void Construct(IHealth health, ICharacter character)
        {
            _health = health.ThrowExceptionIfArgumentNull(nameof(health));
            _behaviourTree = CreateBehaviour(character.ThrowExceptionIfArgumentNull(nameof(character)));
        }

        public bool Died => _health.Died;
        public float Points => _health.Points;

        public void TakeDamage(float damage) =>
            _health.TakeDamage(damage);

        private void Update()
        {
            var result = _behaviourTree.Execute(Time.deltaTime);

            if (result is Failure or Success)
                _behaviourTree.Reset();
        }

        protected abstract IBehaviourNode CreateBehaviour(ICharacter character);
    }
}