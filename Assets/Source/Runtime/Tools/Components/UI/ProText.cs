using TMPro;

namespace FPS.Tools
{
    public sealed class ProText : TextMeshProUGUI, IText
    {
        public void Visualize(string value) =>
            text = value;
    }
}