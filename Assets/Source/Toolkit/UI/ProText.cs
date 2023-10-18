using TMPro;

namespace FPS.Toolkit
{
    public sealed class ProText : TextMeshProUGUI, IText
    {
        public void Visualize(string value) =>
            text = value;
    }
}