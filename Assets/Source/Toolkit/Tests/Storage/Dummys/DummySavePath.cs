using FPS.Toolkit.Storage;

namespace FPS.Toolkit.Tests.Dummys
{
    internal sealed class DummySavePath: IPath
    {
        private readonly IPath _path;

        public DummySavePath() => 
            _path = new Path("Dummy Data Path");

        public string Name => _path.Name;
    }
}