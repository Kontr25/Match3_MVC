using System.Collections.Generic;

namespace Saves.MenuSaveManager
{
    public class MenuSaveManagerController: MenuSaveManagerControllerAbstract
    {
        public MenuSaveManagerController(MenuSaveManagerModelAbstract model, MenuSaveManagerViewAbstract view) : base(model, view)
        {
            Subscribe();
            _model.SetFirstPlaceCount(_view.FirstPlaceCount);
        }
        
        public override void LoadData()
        {
            _model.LoadData(_view.RandomNames);
        }

        public override List<string> GetPlayerNames()
        {
            return _model.GetPlayerNames();
        }

        public override List<int> GetRecordScores()
        {
            return _model.GetRecordScores();
        }

        public override void AddPlayer(string playerName, int score)
        {
            _model.AddPlayer(playerName, score);
        }

        public override void Dispose()
        {
            Unsubscribe();
        }

        public override void Subscribe()
        {
            _model.OnSavesUpdate += _view.UpdateRecordWindow;
            _model.OnClearSaves += LoadData;
            _view.OnClearSaves += _model.ClearSaves;
            _view.Subscribe();
        }

        public override void Unsubscribe()
        {
            
            _model.OnSavesUpdate -= _view.UpdateRecordWindow;
            _model.OnClearSaves -= LoadData;
            _view.OnClearSaves -= _model.ClearSaves;
            _view.Unsubscribe();
        }
    }
}