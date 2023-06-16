using FPS.Tools;

namespace FPS.Data.Scenes
{
    public interface IScenes
    {
        IScene Menu { get; }
        IScene Game { get; }
    }
}