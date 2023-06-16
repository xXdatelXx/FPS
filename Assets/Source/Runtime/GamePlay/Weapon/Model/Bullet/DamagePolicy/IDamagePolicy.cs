namespace FPS.Model
{
    public interface IDamagePolicy
    {
        float Affect(float damage, float distance);
    }
}