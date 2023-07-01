using FPS.Toolkit;
using UnityEngine;
using static FPS.Toolkit.BehaviourNodeStatus;

namespace FPS.GamePlay
{
    public sealed class WaitNode : IBehaviourNode
    {
        private readonly float _delay;
        private float _time;

        public WaitNode(float delay) => 
            _delay = delay.ThrowExceptionIfValueSubZero(nameof(delay));

        public BehaviourNodeStatus Execute(float time)
        {
            _time = Mathf.Min(_time + time, _delay);

            if (_time == _delay)
            {
                Reset();
                return Success;
            }

            return Running;
        }

        public void Reset() => _time = 0;
    }
}