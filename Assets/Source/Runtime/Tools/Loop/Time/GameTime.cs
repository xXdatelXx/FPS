using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FPS.Tools.GameLoop
{
    public sealed class GameTime : IGameTime
    {
        public bool Active => Time.timeScale != 0;
        public float FrameDelta => Time.deltaTime;

        public void Enable() => Time.timeScale = 1;
        public void Disable() => Time.timeScale = 0;

        public async UniTask NextFrame() => await UniTask.Yield(PlayerLoopTiming.Update);
    }
}