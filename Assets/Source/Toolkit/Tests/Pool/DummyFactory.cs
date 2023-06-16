namespace FPS.Toolkit.Tests
{
    internal class DummyFactory : IFactory<DummyObject>
    {
        public bool Created { get; private set; }

        public DummyObject Create()
        {
            Created = true;
            return new DummyObject();
        }
    }
}