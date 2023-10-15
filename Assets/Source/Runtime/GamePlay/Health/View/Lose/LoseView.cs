using Cysharp.Threading.Tasks;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class LoseView : MonoBehaviour, ILoseView
    {
        [SerializeField] private FadePanel _fadePanel;
        [SerializeField] private Canvas _gameCanvas;
        [SerializeField] private Transform _character;
        [SerializeField] private Camera _loseCamera;
        [SerializeField] private string _loseAnimation;
        [SerializeField] private Animator _animator;
        private IScore _score;
        private IScoreView _scoreView;

        public void Construct(IScore score, IScoreView scoreView)
        {
            _score = score.ThrowExceptionIfArgumentNull(nameof(score));
            _scoreView = scoreView.ThrowExceptionIfArgumentNull(nameof(scoreView));
        }

        public void Visualize() => 
            StartLoseAnimation().Forget();

        private async UniTaskVoid StartLoseAnimation()
        {
            _scoreView.Visualize(_score.Value);

            _fadePanel.FadeIn();
            
            var timerForFoolFade = new AsyncTimer(_fadePanel.FadeTime);
            timerForFoolFade.Play();
            await timerForFoolFade.End();

            _loseCamera.gameObject.SetActive(true);
            _gameCanvas.gameObject.SetActive(false);
            _character.gameObject.SetActive(false);

            _fadePanel.FadeOut();
            
            _animator.Play(_loseAnimation);
        }
    }
}