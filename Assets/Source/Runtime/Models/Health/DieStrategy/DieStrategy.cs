namespace Source.Runtime.Model.Health
{
    public sealed class DieStrategy : IDieStrategy
    {
        public void Die() => 
            Logger.Log("рак");
    }
}