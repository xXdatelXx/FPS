namespace Source.Runtime.Models.Game.Loop.Time
{
    public sealed class GameTime : IGameTime
    {
        public bool Active => UnityEngine.Time.timeScale != 0;
        public float FixedDelta => UnityEngine.Time.fixedDeltaTime;
        public float Delta => UnityEngine.Time.deltaTime;

        public void Stop() => UnityEngine.Time.timeScale = 0;
        public void Enable() => UnityEngine.Time.timeScale = 1;
    }
}