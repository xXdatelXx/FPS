namespace Source.Runtime.Models.Weapons.Bullet
{
    public interface IDamageCoefficient
    {
        float Get(float distance);
    }
}