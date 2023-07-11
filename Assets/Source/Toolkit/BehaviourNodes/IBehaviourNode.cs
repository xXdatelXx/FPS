namespace FPS.Toolkit
{
    public interface IBehaviourNode
    {
        BehaviourNodeStatus Status { get; }
        
        BehaviourNodeStatus Execute(float time);
        void Reset();
    }
}