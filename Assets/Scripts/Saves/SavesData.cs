using System;
using System.Collections.Generic;
using System.Linq;

namespace Saves
{
    [Serializable]
    public class SavesData
    {
        public int FirstPlaceCount;
        public List<string> PlayerNames = new List<string>();
        public List<int> RecordScores = new List<int>();
        
        // Добавление данных нового рекордсмена 
        public void AddPlayer(string playerName, int recordScore)
        {
            PlayerNames.Add(playerName);
            RecordScores.Add(recordScore);
            
            SortPlayers();
        }

        // Сортировка списка рекордсменов в порядке убывания рекордов 
        private void SortPlayers()
        {
            List<(string playerName, int recordScore)> players = new List<(string, int)>();
            for (int i = 0; i < PlayerNames.Count; i++)
            {
                players.Add((PlayerNames[i], RecordScores[i]));
            }

            players.Sort((a, b) => b.recordScore.CompareTo(a.recordScore));

            PlayerNames = players.Select(p => p.playerName).ToList();
            RecordScores = players.Select(p => p.recordScore).ToList();
        }
    }
}