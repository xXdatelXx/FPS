using FPS.Toolkit;

namespace FPS.Data
{
    public interface IScenes
    {
        IScene Menu { get; }
        IScene Game { get; }
    }
}