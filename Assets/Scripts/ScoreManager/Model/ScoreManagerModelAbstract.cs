using System;

namespace ScoreManager
{
    public abstract class ScoreManagerModelAbstract
    {
        public abstract event Action<int> OnGameOver; // Событие, которое вызывается когда у игрока заканчиваются очки
        public abstract event Action<int,int> OnScorePointsRemaining; // Событие, которое вызывается когда у игрока еще есть очки для следующего хода
        
        protected int _currentScore; // Текущее количество очков игрока учитывающее отнимаемые очки за ходы
        protected int _earnedScore; // Количество заработанных за время игры очков
        protected int _scorePerTile; // Количество очков, получаемое игроком за уничтожение одного тайла
        protected int _scoreLostPerMove; // Количество очков, теряемое игроком за один ход
        protected int _numberOfMoves; // Текущее количество ходов

        public abstract int CurrentScore { get; }

        public abstract int EarnedScore { get; }

        protected ScoreManagerModelAbstract(int startingPlayerScore, int scorePerTile, int scoreLostPerMove)
        {
            _currentScore = startingPlayerScore;
            _scorePerTile = scorePerTile;
            _scoreLostPerMove = scoreLostPerMove;
        }

        public abstract void HandleTileDestruction(int numberOfDestroyedTiles); // Обработка количества уничтоженных тайлов за ход
    }
}