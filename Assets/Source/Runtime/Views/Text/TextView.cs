using Source.Runtime.Tools.Components.UI;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Views.Text
{
    public sealed class TextView : ITextView
    {
        private readonly IText _text;

        public TextView(IText text) => 
            _text = text.ThrowExceptionIfArgumentNull();

        public void Visualize(string text) => 
            _text.Set(text);

        public void Visualize(int text)
        {
            throw new System.NotImplementedException();
        }
    }
}