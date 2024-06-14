using System;

namespace ScoreManager
{
    public class ScoreManagerController: ScoreManagerControllerAbstract
    {
        /// <summary>
        /// Управляет взаимодействием между моделью менеджера очков и его представлением.
        /// Отвечает за подсчет получаемых очков игроком, а так же за их окончанием
        /// </summary>
        
        public override event Action<int> OnGameOver;
        public ScoreManagerController(ScoreManagerModelAbstract model, ScoreManagerViewAbstract view) : base(model, view)
        {
            Subscribe();
            _view.UpdateScoreWindow(_model.EarnedScore,_model.CurrentScore);
        }
        
        public override void HandleTileDestruction(int numberOfDestroyedTiles)
        {
            _model.HandleTileDestruction(numberOfDestroyedTiles);
        }

        public override void GameOver(int score)
        {
            OnGameOver?.Invoke(score);
        }

        public override void Dispose()
        {
            Unsubscribe();
        }

        public override void Subscribe()
        {
            _model.OnScorePointsRemaining += _view.UpdateScoreWindow;
            _model.OnGameOver += GameOver;
        }

        public override void Unsubscribe()
        {
            _model.OnScorePointsRemaining -= _view.UpdateScoreWindow;
            _model.OnGameOver -= GameOver;
        }
    }
}