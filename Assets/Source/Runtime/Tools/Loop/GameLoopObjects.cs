using System.Collections.Generic;
using System.Linq;

namespace FPS.Tools.GameLoop
{
    public sealed class GameLoopObjects : IGameLoopObjects
    {
        private readonly List<IGameLoopObject> _loopObjects;

        public GameLoopObjects(IEnumerable<IGameLoopObject> loopObjects) => 
            _loopObjects = loopObjects.TryThrowNullReferenceForeach(nameof(loopObjects)).ToList();

        public GameLoopObjects() : this(new List<IGameLoopObject>())
        {
        }

        public void Add(IGameLoopObject loopObject) => 
            _loopObjects.Add(loopObject.ThrowExceptionIfArgumentNull(nameof(loopObject)));

        public void Tick(float deltaTime) => 
            _loopObjects.ForEach(i => i.Tick(deltaTime));
    }
}