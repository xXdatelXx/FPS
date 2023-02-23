using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Source.Runtime.Models.Game.Loop.Tickables;
using Source.Runtime.Models.Game.Loop.Time;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Models.Game.Loop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly List<IFixedTickable> _fixedTickables = new();
        private readonly List<ILateTickable> _lateTickables = new();
        private readonly List<ITickable> _tickables = new();
        private readonly IReadOnlyGameTime _time;

        public GameLoop(IReadOnlyGameTime time) =>
            _time = time.ThrowExceptionIfArgumentNull(nameof(time));

        public void Add(ITickable tickable) =>
            _tickables.Add(tickable.ThrowExceptionIfArgumentNull(nameof(tickable)));

        public void Add(ILateTickable tickable) =>
            _lateTickables.Add(tickable.ThrowExceptionIfArgumentNull(nameof(tickable)));

        public void Add(IFixedTickable tickable) =>
            _fixedTickables.Add(tickable.ThrowExceptionIfArgumentNull(nameof(tickable)));

        public void Start()
        {
            Start(UniTask.Yield(),
                () => _tickables.ForEach(i => i.Tick(_time.Delta)));
            Start(UniTask.Yield(PlayerLoopTiming.PostLateUpdate),
                () => _lateTickables.ForEach(i => i.LateTick()));
            Start(UniTask.WaitForFixedUpdate(),
                () => _fixedTickables.ForEach(i => i.FixedTick(_time.FixedDelta)));
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