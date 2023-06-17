namespace FPS.Model
{
    public static class HealthExtension
    {
        public static bool Alive(this IReadOnlyHealth health) =>
            health.Died == false;
    }
}