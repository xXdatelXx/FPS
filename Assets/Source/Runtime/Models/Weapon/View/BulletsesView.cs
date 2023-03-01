using FPS.Tools;
using FPS.Views.Text;

namespace FPS.Model
{
    public sealed class BulletsesView : IBulletsView
    {
        private readonly ITextView _text;

        public BulletsesView(ITextView text) =>
            _text = text.ThrowExceptionIfArgumentNull(nameof(text));

        public void Visualize(int bullets) =>
            _text.Visualize(bullets);
    }
}