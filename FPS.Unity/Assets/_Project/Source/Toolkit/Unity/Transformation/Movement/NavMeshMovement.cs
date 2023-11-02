using UnityEngine;
using UnityEngine.AI;

namespace FPS.Toolkit
{
    public sealed class NavMeshMovement : IMovement
    {
        private readonly NavMeshAgent _agent;

        public NavMeshMovement(NavMeshAgent agent)
        {
            _agent = agent.ThrowExceptionIfArgumentNull(nameof(agent));
            Position = new Position(_agent.transform);
        }

        public IReadOnlyPosition Position { get; }

        public void Move(Vector3 motion) => _agent.SetDestination(motion);
    }
}