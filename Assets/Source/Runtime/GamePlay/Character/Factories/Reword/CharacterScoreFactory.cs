using FPS.GamePlay;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class CharacterScoreFactory : MonoBehaviour, IFactory<IScore>
    {
        [SerializeField] private ProText _scoreText;
        
        public IScore Create()
        {
            var scoreView = new ScoreView(_scoreText);
            return new ScoreWithSave(new Score(scoreView), nameof(Character));
        }
    }
}