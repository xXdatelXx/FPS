using DG.Tweening;
using UnityEngine;

namespace FPS.Toolkit
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadePanel : MonoBehaviour, IFadePanel
    {
        [SerializeField] private OnStart _onStart;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();

            if (_onStart is not OnStart.Null)
                Fade((int)--_onStart);
        }

        [field: SerializeField] public float FadeTime { get; private set; }

        public void FadeIn() => Fade(1);

        public void FadeOut() => Fade(0);

        private void Fade(int endValue)
        {
            _canvasGroup.DOFade(Mathf.Abs(1 - endValue), 0);
            _canvasGroup.DOFade(endValue, FadeTime);

            bool visible = endValue == 1;
            _canvasGroup.interactable = visible;
            _canvasGroup.blocksRaycasts = visible;
        }

        private enum OnStart
        {
            Null,
            FadeOut,
            FadeIn
        }
    }
}