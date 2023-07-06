using FPS.Toolkit;
using static FPS.Toolkit.BehaviourNodeStatus;

namespace FPS.GamePlay
{
    public sealed class AttackWithWeaponNode : IBehaviourNode
    {
        private readonly IWeapon _weapon;

        public AttackWithWeaponNode(IWeapon weapon) => 
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
        
        public BehaviourNodeStatus Execute(float time)
        {
            if (_weapon.CanShoot)
            {
                _weapon.Shoot();
                return Success;
            }

            return Failure;
        }

        public void Reset()
        { }
    }
}