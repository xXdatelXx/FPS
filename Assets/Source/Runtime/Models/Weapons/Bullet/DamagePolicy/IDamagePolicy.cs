namespace Source.Runtime.Models.Weapons.Bullet
{
    public interface IDamagePolicy
    {
        float Affect(float damage, float distance);
    }
}