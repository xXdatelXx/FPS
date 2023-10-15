using FPS.Toolkit;
using FPS.Toolkit.View;
using FPS.Ui;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class LoseFactory : MonoBehaviour, ILoseFactory
    {
        [SerializeField] private ProText3D _score;
        [SerializeField] private LoseView _lose;
        [SerializeField] private KeyButton _exitButton;
        [SerializeField] private FadePanel _exitFadePanel;
        [SerializeField] private Scene _exitScene;
        
        public ILoseView Create(IScore score)
        {
            var asyncLoadGameScene = new AsyncScene(_exitScene, _exitFadePanel.FadeTime);
            var sceneWithLoadView = new SceneWithLoadView(asyncLoadGameScene, new FadePanelSceneLoadView(_exitFadePanel));
            
            _exitButton.Subscribe(new SceneLoadButton(sceneWithLoadView));
            _lose.Construct(score, new ScoreView(_score));
            
            return _lose;
        }
    }
}