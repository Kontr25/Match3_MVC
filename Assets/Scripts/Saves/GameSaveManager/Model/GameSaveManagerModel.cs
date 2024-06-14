using System;

namespace Saves.GameSaveManager
{
    public class GameSaveManagerModel: GameSaveManagerModelAbstract
    {
        public override event Action<int> OnSuccessfulComparison;
        public override event Action<int> OnFailedComparison;

        public override void AddPlayer(string playerName, int score)
        {
            _savesData.AddPlayer(playerName, score);
            Save();
        }

        public override void CompareScoresWithTopThree(int score)
        {
            for (int i = 0; i < _firstPlaceCount; i++)
            {
                if (score > _savesData.RecordScores[i])
                {
                    OnSuccessfulComparison?.Invoke(score);
                    return;
                }
            }
            OnFailedComparison?.Invoke(score);
        }

        protected override void Save()
        {
            _storage.Save(_savesData);
        }
    }
}