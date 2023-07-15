using DG.Tweening;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.Visual
{
    public sealed class CameraShake : ICameraShake
    {
        private readonly Camera _camera;
        private readonly float _duration;
        private readonly float _strength;

        public CameraShake(Camera camera, float duration = 0.1f, float strength = 0.5f)
        {
            _camera = camera.ThrowExceptionIfArgumentNull(nameof(camera));
            _duration = duration.ThrowExceptionIfValueSubZero(nameof(duration));
            _strength = strength;
        }

        public void Shake() => 
            _camera.DOShakeRotation(_duration, _strength);
    }
}