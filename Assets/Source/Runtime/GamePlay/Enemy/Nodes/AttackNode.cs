using FPS.Toolkit;
using static FPS.Toolkit.BehaviourNodeStatus;

namespace FPS.GamePlay
{
    public sealed class AttackNode : IBehaviourNode
    {
        private readonly IHealth _target;
        private readonly float _damage;

        public AttackNode(IHealth target, float damage)
        {
            _target = target.ThrowExceptionIfArgumentNull(nameof(target));
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
        }

        public BehaviourNodeStatus Execute(float time)
        {
            if (_target.Alive())
            {
                _target.TakeDamage(_damage);
                return Success;
            }
            
            return Failure;
        }

        public void Reset()
        { }
    }
}