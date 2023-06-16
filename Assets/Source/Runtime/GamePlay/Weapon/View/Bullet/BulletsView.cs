using FPS.Toolkit;

namespace FPS.Model
{
    public sealed class BulletsView : IBulletsView
    {
        private readonly IText _text;

        public BulletsView(IText text) =>
            _text = text.ThrowExceptionIfArgumentNull(nameof(text));

        public void Visualize(int bullets) =>
            _text.Visualize(bullets);
    }
}