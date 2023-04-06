using FPS.Tools.GameLoop;

namespace FPS.Tools
{
    public static class GameLoopExtension
    {
        public static void Add(this IReadOnlyGameLoop loop, params IGameLoopObject[] objects)
        {
            foreach (var i in objects) 
                loop.Add(i);
        }
        
        public static void Add(this IReadOnlyGameLoop loop, params IFixedGameLoopObject[] objects)
        {
            foreach (var i in objects) 
                loop.Add(i);
        }
        
        public static void Add(this IReadOnlyGameLoop loop, params ILateGameLoopObject[] objects)
        {
            foreach (var i in objects) 
                loop.Add(i);
        }
    }
}