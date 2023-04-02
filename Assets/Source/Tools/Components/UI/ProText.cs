using TMPro;

namespace FPS.Tools
{
    public sealed class ProText : TextMeshProUGUI, IText
    {
        public void Set(string value) =>
            text = value;
    }
}