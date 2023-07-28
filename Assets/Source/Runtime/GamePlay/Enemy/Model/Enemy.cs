using FPS.Toolkit;
using UnityEngine;
using static FPS.Toolkit.BehaviourNodeStatus;

namespace FPS.GamePlay
{
    [RequireComponent(typeof(Collider))]
    public abstract class Enemy : MonoBehaviour, IHealth
    {
        [SerializeField, Range(0, 200)] private float _healthPoints;
        [SerializeField] private EnemyHealthView _healthView;
        private IHealth _health;
        private IBehaviourNode _behaviourTree;

        public void Construct(ICharacter character, IReword reword)
        {
            _behaviourTree = CreateBehaviour(character.ThrowExceptionIfArgumentNull(nameof(character)));
            _healthView.Construct(reword.ThrowExceptionIfArgumentNull(nameof(reword)));
            _health = new Health(_healthPoints, _healthView);
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