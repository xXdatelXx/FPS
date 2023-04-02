using UnityEngine;

namespace FPS.Tools.GameLoop
{
    public sealed class GameTime : IGameTime
    {
        public bool Active => Time.timeScale != 0;
        public float FixedDelta => Time.fixedDeltaTime;
        public float Delta => Time.deltaTime;

        public void Stop() => Time.timeScale = 0;
        public void Enable() => Time.timeScale = 1;
    }
}