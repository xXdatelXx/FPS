using System.Collections.Generic;
using System.Linq;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletViewSequence : IBulletView
    {
        private readonly List<IBulletView> _views;

        public BulletViewSequence(List<IBulletView> views) =>
            _views = views.TryThrowNullReferenceForeach(nameof(views)).ToList();

        public BulletViewSequence(params IBulletView[] views) : this(views.ToList())
        { }

        public void Miss() =>
            _views.ForEach(i => i.Miss());

        public void Hit(Vector3 target) =>
            _views.ForEach(i => i.Hit(target));

        public void Kill() =>
            _views.ForEach(i => i.Kill());

        public void Damage() =>
            _views.ForEach(i => i.Damage());
    }
}