using FPS.Toolkit;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.GamePlay
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
    public sealed class Zombie : Enemy
    {
        [SerializeField, Range(0, 100)] private float _damage;
        [SerializeField, Range(0, 10)] private float _attackDelay;
        [SerializeField] private string _attackAnimation;

        protected override IBehaviourNode CreateBehaviour(ICharacter character)
        {
            var agent = GetComponent<NavMeshAgent>();
            var movement = new NavMeshMovement(agent);
            var attackView = new AttackView(new UnityAnimation(GetComponent<Animator>(), _attackAnimation));

            return new BehaviourNodeSequence
            (
                new MoveNode(movement, character.Movement.Position, agent.stoppingDistance),
                new AttackNode(character.Health, _damage, attackView),
                new WaitNode(_attackDelay)
            );
        }
    }
}