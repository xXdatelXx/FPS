using UnityEngine;
using UnityEngine.UI;

namespace FPS.Toolkit
{
    [RequireComponent(typeof(Slider))]
    public sealed class UnitySlider : MonoBehaviour, IUnitySlider
    {
        private ISlider _slider;
        private Slider _unitySlider;

        private void Awake() =>
            _unitySlider = GetComponent<Slider>();
        
        public void Subscribe(ISlider slider, float value = 0)
        {
            _slider = slider.ThrowExceptionIfArgumentNull(nameof(slider));
            _unitySlider.value = value.ThrowExceptionIfValueSubZero(nameof(value));
            _unitySlider.onValueChanged.AddListener(_slider.Slide);
        }

        private void OnDestroy() =>
            _unitySlider.onValueChanged.RemoveListener(_slider.Slide);
    }
}