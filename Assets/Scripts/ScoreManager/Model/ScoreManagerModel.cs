using System;

namespace ScoreManager
{
    public class ScoreManagerModel: ScoreManagerModelAbstract
    {
        public override event Action<int> OnGameOver;
        public override event Action<int, int> OnScorePointsRemaining;
        public override int CurrentScore => _currentScore;
        public override int EarnedScore => _earnedScore;

        public ScoreManagerModel(int startingPlayerScore, int scorePerTile, int scoreLostPerMove) : base(startingPlayerScore, scorePerTile, scoreLostPerMove)
        {
        }
        
        public override void HandleTileDestruction(int numberOfDestroyedTiles)
        {
            _numberOfMoves++;
            
            _earnedScore = EarnedScore + (numberOfDestroyedTiles * _scorePerTile);
            
            int scoreToAdd = (numberOfDestroyedTiles * _scorePerTile) - (_scoreLostPerMove + _numberOfMoves);
            _currentScore = CurrentScore + scoreToAdd;
            if (CurrentScore <= 0)
            {
                _currentScore = 0;
                OnGameOver?.Invoke(EarnedScore);
            }
            OnScorePointsRemaining?.Invoke(EarnedScore, CurrentScore);
        }

    }
}