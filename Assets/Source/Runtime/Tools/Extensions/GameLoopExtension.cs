using FPS.Tools.GameLoop;

namespace FPS.Tools
{
    public static class GameLoopExtension
    {
        public static void Add(this IReadOnlyGameLoop loop, params ITickable[] tickables)
        {
            foreach (var i in tickables) 
                loop.Add(i);
        }
        
        public static void Add(this IReadOnlyGameLoop loop, params IFixedTickable[] tickables)
        {
            foreach (var i in tickables) 
                loop.Add(i);
        }
        
        public static void Add(this IReadOnlyGameLoop loop, params ILateTickable[] tickables)
        {
            foreach (var i in tickables) 
                loop.Add(i);
        }
    }
}