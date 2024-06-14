namespace Saves.GameSaveManager
{
    public class GameSaveManagerController: GameSaveManagerControllerAbstract
    {
        public GameSaveManagerController(GameSaveManagerModelAbstract model, GameSaveManagerViewAbstract view) : base(model, view)
        {
            Subscribe();
        }
        

        public override void AddPlayer(string playerName, int score)
        {
            _model.AddPlayer(playerName, score);
        }

        public override void TrySaveNewRecord(int score)
        {
            _model.CompareScoresWithTopThree(score);
        }

        public override void Dispose()
        {
            Unsubscribe();
        }

        public override void Subscribe()
        {
            _model.OnSuccessfulComparison += _view.EnableNewRecordWindow;
            _model.OnFailedComparison += _view.EnableGameOverWindow;
            _view.OnSaveNewRecord += _model.AddPlayer;
        }

        public override void Unsubscribe()
        {
            _model.OnSuccessfulComparison -= _view.EnableNewRecordWindow;
            _model.OnFailedComparison -= _view.EnableGameOverWindow;
            _view.OnSaveNewRecord -= _model.AddPlayer;
        }
    }
}