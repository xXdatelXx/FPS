using Cysharp.Threading.Tasks;

namespace FPS.Tools
{
    public static class TimerExtension
    {
        public static async UniTask End(this ITimer timer) =>
            await UniTask.WaitUntil(() => !timer.Playing);
    }
}