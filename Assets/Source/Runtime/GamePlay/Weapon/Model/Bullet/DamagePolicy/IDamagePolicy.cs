namespace FPS.GamePlay
{
    public interface IDamagePolicy
    {
        float Affect(float damage, float distance);
    }
}