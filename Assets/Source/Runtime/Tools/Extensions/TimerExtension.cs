using Cysharp.Threading.Tasks;

namespace FPS.Tools
{
    public static class TimerExtension
    {
        public static async UniTask End(this IReadOnlyTimer timer) =>
            await UniTask.WaitUntil(() => !timer.Playing);
    }
}