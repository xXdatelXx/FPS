using FPS.Toolkit;
using static FPS.Toolkit.BehaviourNodeStatus;

namespace FPS.GamePlay
{
    public sealed class AttackWithWeaponNode : IBehaviourNode
    {
        private readonly IWeapon _weapon;

        public AttackWithWeaponNode(IWeapon weapon) => 
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));

        public BehaviourNodeStatus Status { get; private set; }

        public BehaviourNodeStatus Execute(float time)
        {
            if (_weapon.CanShoot)
            {
                _weapon.Shoot();
                return Status = Success;
            }

            return Status = Failure;
        }

        public void Reset() => 
            Status = Idle;
    }
}