using UnityEngine;

namespace ScriptableObjects
{        
    [CreateAssetMenu(fileName = nameof(GameData), menuName = "Configs/" + nameof(GameData), order = 1)]
    public class GameData: ScriptableObject
    {
        /// <summary>
        /// Дефолтьные данные игры
        /// </summary>
        [Range(2,12)]
        public int GridRowsCount;
        [Range(2,17)]
        public int GridColumnsCount;
        public int StartingPlayerScore;
        public int ScorePerTile;
        public int ScoreLostPerMove;
        
    }
}