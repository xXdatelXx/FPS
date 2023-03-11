using System.Collections.Generic;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletHitsView : IBulletHitsView
    {
        private readonly int _maxHits;
        private readonly Queue<IBulletHitView> _hits;
        private readonly IPool<IBulletHitView> _hitsPool;

        public BulletHitsView(int maxHits, IPool<IBulletHitView> hitsPool)
        {
            _maxHits = maxHits.ThrowExceptionIfValueSubOrEqualZero(nameof(maxHits));
            _hitsPool = hitsPool.ThrowExceptionIfArgumentNull(nameof(hitsPool));
            _hits = new();
        }

        public void Visualize(Vector3 target, Vector3 normal)
        {
            var hit = _hitsPool.Get();
            hit.Visualize(target, normal);
            _hits.Enqueue(hit);

            if (_maxHits < _hits.Count) 
                Hide();
        }

        private void Hide()
        {
            var disableHit = _hits.Dequeue();
            disableHit.Hide();
            _hitsPool.Return(disableHit);
        }
    }
}