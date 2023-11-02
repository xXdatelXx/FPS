using FPS.Input;
using FPS.Toolkit;

namespace FPS.Ui
{
    public sealed class MouseSensitivitySlider : ISlider
    {
        private readonly IMouseSensitivity _sensitivity;

        public MouseSensitivitySlider(IMouseSensitivity sensitivity) =>
            _sensitivity = sensitivity.ThrowExceptionIfArgumentNull(nameof(sensitivity));

        public void Slide(float value)
        {
            if (value != _sensitivity.Value)
                _sensitivity.Update(value);
        }
    }
}