namespace FPS.Tools
{
    public sealed class TextView : ITextView
    {
        private readonly IText _text;

        public TextView(IText text) =>
            _text = text.ThrowExceptionIfArgumentNull(nameof(text));

        public void Visualize(object obj) => _text.Set(obj.ToString());
    }
}