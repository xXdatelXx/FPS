using TMPro;

namespace FPS.Toolkit
{
    public sealed class ProText3D : TextMeshPro, IText
    {
        public void Visualize(string value) =>
            text = value;
    }
}