using System.Collections.Generic;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletHitsView : IBulletHitView
    {
        private readonly Queue<IBulletHitView> _hits;
        private readonly IPool<IBulletHitView> _hitsPool;
        private readonly int _maxHits;

        public BulletHitsView(IPool<IBulletHitView> hitsPool, int maxHits)
        {
            _maxHits = maxHits.ThrowExceptionIfValueSubOrEqualZero(nameof(maxHits));
            _hitsPool = hitsPool.ThrowExceptionIfArgumentNull(nameof(hitsPool));
            _hits = new();
        }

        public void Visualize(Vector3 target)
        {
            var hit = _hitsPool.Get();
            hit.Visualize(target);
            _hits.Enqueue(hit);

            if (_maxHits < _hits.Count)
                HideFirst();
        }

        public void Hide()
        {
            foreach (var i in _hits)
                _hitsPool.Return(i);
        }

        private void HideFirst()
        {
            var disableHit = _hits.Dequeue();
            disableHit.Hide();
            _hitsPool.Return(disableHit);
        }
    }
}