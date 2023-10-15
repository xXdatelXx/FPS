using FPS.Toolkit;
using FPS.Toolkit.Storage;

namespace FPS.GamePlay
{
    public sealed class ScoreWithSave : IScore 
    {
        private readonly IScore _score;
        private readonly IStorage<int> _storage;
        private readonly IScoreView _maxScoreView;
        private int _maxScore;
        
        public ScoreWithSave(string storageName) 
            : this(new Score(), storageName)
        { }
        
        public ScoreWithSave(IScore score, string storageName) 
            : this(score, storageName, new NullScoreView())
        { }
        
        public ScoreWithSave(IScore score, string storageName, IScoreView maxScoreView) 
            : this(score, new BinaryStorage<int>(storageName), maxScoreView)
        { }

        public ScoreWithSave(IScore score, IStorage<int> storage, IScoreView maxScoreView)
        {
            _score = score.ThrowExceptionIfArgumentNull(nameof(score));
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));
            _maxScoreView = maxScoreView.ThrowExceptionIfArgumentNull(nameof(maxScoreView));
            
            _maxScore = _storage.LoadOrDefault();
            _maxScoreView.Visualize(_maxScore);
        }

        public int Value => _score.Value;
        
        public void Increase(int value)
        {
            _score.Increase(value);

            if (_maxScore < _score.Value)
            {
                _storage.Save(_score.Value);
                _maxScore = _score.Value;
                _maxScoreView.Visualize(_maxScore);
            }
        }
    }
}