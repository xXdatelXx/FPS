using FPS.Toolkit;
using static FPS.Toolkit.BehaviourNodeStatus;

namespace FPS.GamePlay
{
    public sealed class AttackNode : IBehaviourNode
    {
        private readonly IHealth _target;
        private readonly float _damage;
        private readonly IAttackView _view;

        public AttackNode(IHealth target, float damage, IAttackView view)
        {
            _target = target.ThrowExceptionIfArgumentNull(nameof(target));
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public BehaviourNodeStatus Execute(float time)
        {
            _view.Attack();
            
            if (_target.Alive()) 
                _target.TakeDamage(_damage);

            return Success;
        }

        public void Reset()
        { }
    }
}