namespace FPS.Toolkit
{
    public interface IBehaviourNode
    {
        BehaviourNodeStatus Execute(float time);
        void Reset();
    }
}