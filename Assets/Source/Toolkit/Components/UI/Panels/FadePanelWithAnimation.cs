using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.Toolkit
{
    [RequireComponent(typeof(FadePanel))]
    public sealed class FadePanelWithAnimation : SerializedMonoBehaviour
    {
        [SerializeField] private AsyncTimer _timerToFadeIn;
        [SerializeField] private AsyncTimer _timerToFadeOut;
        private IFadePanel _fadePanel;

        private void Awake()
        {
            _fadePanel = GetComponent<FadePanel>();
            StartAnimationLoop().Forget();
        }

        private async UniTaskVoid StartAnimationLoop()
        {
            while (true)
            {
                await Animate(_timerToFadeIn, () => _fadePanel.FadeIn());
                await Animate(_timerToFadeOut, () => _fadePanel.FadeOut());
            }
        }

        private static async UniTask Animate(ITimer timer, Action animation)
        {
            timer.Play();
            await timer.End();

            animation.Invoke();
        }
    }
}