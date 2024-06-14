using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Saves.MenuSaveManager
{
    public class MenuSaveManagerModel: MenuSaveManagerModelAbstract
    {
        public override event Action<List<string>, List<int>> OnSavesUpdate;
        public override event Action OnClearSaves;

        public override void LoadData(string[] randomNames)
        {
            _savesData = (SavesData)_storage.Load(new SavesData());
            
            if (_savesData.PlayerNames.Count == 0)
            {
                RandomNameGenerator randomNameGenerator = new RandomNameGenerator(randomNames);
                _savesData.FirstPlaceCount = _firstPlaceCount;
                
                for (int i = 0; i < _firstPlaceCount; i++)
                {
                    AddPlayer(randomNameGenerator.GetUniqueRandomName(), Random.Range(10, 31));
                }
                
                Save();
            }
            
            OnSavesUpdate?.Invoke(GetPlayerNames(), GetRecordScores());
        }

        public override void SetFirstPlaceCount(int firstPlaceCount)
        {
            _firstPlaceCount = firstPlaceCount;
        }

        public override List<string> GetPlayerNames()
        {
            return _savesData.PlayerNames;
        }

        public override List<int> GetRecordScores()
        {
            return _savesData.RecordScores;
        }

        public override void AddPlayer(string playerName, int score)
        {
            _savesData.AddPlayer(playerName, score);
            Save();
        }

        protected override void Save()
        {
            _storage.Save(_savesData);
        }

        public override void ClearSaves()
        {
            _storage.ClearSaves();
            _savesData = (SavesData)_storage.Load(new SavesData());
            Save();
            OnClearSaves?.Invoke();
        }
    }
}