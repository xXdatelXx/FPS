namespace FPS.Tools
{
    public static class TextExtension
    {
        public static void Visualize(this IText text, object value) =>
            text.Visualize(value.ToString());
    }
}