using FPS.Toolkit;
using static FPS.Toolkit.BehaviourNodeStatus;

namespace FPS.GamePlay
{
    public sealed class MoveNode : IBehaviourNode
    {
        private readonly IMovement _movement;
        private readonly IReadOnlyPosition _target;
        private readonly float _successDistance;

        public MoveNode(IMovement movement, IReadOnlyPosition target, float successDistance)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _target = target.ThrowExceptionIfArgumentNull(nameof(target));
            _successDistance = successDistance.ThrowExceptionIfValueSubZero(nameof(successDistance));
        }

        public BehaviourNodeStatus Status { get; private set; }

        public BehaviourNodeStatus Execute(float time)
        {
            _movement.Move(_target.Value);

            return Status = _successDistance <= _target.Distance(_movement.Position)
                ? Running
                : Success;
        }

        public void Reset() => 
            Status = Idle;
    }
}