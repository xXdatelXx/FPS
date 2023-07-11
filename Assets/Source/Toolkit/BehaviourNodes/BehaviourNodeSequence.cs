using System.Linq;
using static FPS.Toolkit.BehaviourNodeStatus;

namespace FPS.Toolkit
{
    public sealed class BehaviourNodeSequence : IBehaviourNode
    {
        private readonly IBehaviourNode[] _childNodes;

        public BehaviourNodeSequence(params IBehaviourNode[] childNodes)
        {
            _childNodes = childNodes
                .TryThrowNullReferenceForeach(nameof(childNodes))
                .ToArray();
        }

        public BehaviourNodeStatus Status { get; private set; }

        public BehaviourNodeStatus Execute(float time)
        {
            foreach (var child in _childNodes)
            {
                if (child.Status is Success)
                    continue;

                var result = child.Execute(time);
                if (result is not Success)
                {
                    Status = result;
                    return result;
                }
            }

            return Status = Success;
        }

        public void Reset()
        {
            foreach (var child in _childNodes)
                child.Reset();

            Status = Idle;
        }
    }
}