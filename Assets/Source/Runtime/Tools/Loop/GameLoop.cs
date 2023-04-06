using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace FPS.Tools.GameLoop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly List<IGameLoopObject> _objects = new();
        private readonly List<IFixedGameLoopObject> _fixedObjects = new();
        private readonly List<ILateGameLoopObject> _lateObjects = new();
        private readonly IReadOnlyGameTime _time;

        public GameLoop(IReadOnlyGameTime time) =>
            _time = time.ThrowExceptionIfArgumentNull(nameof(time));

        #region Add methods

        public void Add(IGameLoopObject obj)
        {
            if (_objects.Has(obj))
                throw new InvalidOperationException(nameof(Add));

            _objects.Add(obj.ThrowExceptionIfArgumentNull(nameof(obj)));
        }

        public void Add(ILateGameLoopObject obj)
        {
            if (_lateObjects.Has(obj))
                throw new InvalidOperationException(nameof(Add));

            _lateObjects.Add(obj.ThrowExceptionIfArgumentNull(nameof(obj)));
        }

        public void Add(IFixedGameLoopObject obj)
        {
            if (_fixedObjects.Has(obj))
                throw new InvalidOperationException(nameof(Add));

            _fixedObjects.Add(obj.ThrowExceptionIfArgumentNull(nameof(obj)));
        }

        #endregion

        public void Start()
        {
            Start(UniTask.Yield(),
                () => _objects.ForEach(i => i.Tick(_time.Delta)));
            Start(UniTask.Yield(PlayerLoopTiming.PostLateUpdate),
                () => _lateObjects.ForEach(i => i.LateTick()));
            Start(UniTask.WaitForFixedUpdate(),
                () => _fixedObjects.ForEach(i => i.FixedTick(_time.FixedDelta)));
        }

        private async void Start(YieldAwaitable yieldAwaitable, Action updateAction)
        {
            while (true)
            {
                await yieldAwaitable;

                if (_time.Active)
                    updateAction.Invoke();
            }
        }
    }
}