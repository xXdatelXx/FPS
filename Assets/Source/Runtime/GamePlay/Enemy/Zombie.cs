using FPS.Toolkit;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.GamePlay
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class Zombie : Enemy
    {
        [SerializeField, Range(0, 100)] private float _damage;
        [SerializeField, Range(0, 10)] private float _attackDistance;
        [SerializeField, Range(0, 10)] private float _attackDelay;

        protected override IBehaviourNode CreateBehaviour(ICharacter character)
        {
            return new BehaviourNodeSequence
            (
                new MoveNode(new NavMeshMovement(GetComponent<NavMeshAgent>()), character.Movement.Position, _attackDistance),
                new AttackNode(character.Health, _damage),
                new WaitNode(_attackDelay)
            );
        }
    }
}