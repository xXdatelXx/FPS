using UnityEngine;

namespace FPS.Toolkit.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class AnimationSceneLoadView : MonoBehaviour, ISceneLoadView
    {
        [SerializeField] private string _loadAnimation;
        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void VisualizeLoad() =>
            _animator.Play(_loadAnimation);
    }
}