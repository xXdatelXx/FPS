namespace FPS.GamePlay
{
    public interface IEnemySimulationFactory
    {
        IEnemySimulation Create(ICharacter character);
    }
}