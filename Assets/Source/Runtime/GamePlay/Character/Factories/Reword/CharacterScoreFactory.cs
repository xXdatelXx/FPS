using FPS.GamePlay;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class CharacterScoreFactory : MonoBehaviour, IFactory<IScore>
    {
        [SerializeField] private ProText _scoreText;
        [SerializeField] private ProText3D _maxScoreText;
        
        public IScore Create()
        {
            var scoreView = new ScoreView(_scoreText);
            return new ScoreWithSave(new Score(scoreView), nameof(Character), new ScoreView(_maxScoreText));
        }
    }
}