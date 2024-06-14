using UnityEngine;

namespace ScoreManager
{
    public abstract class ScoreManagerViewAbstract: MonoBehaviour
    {
        public abstract void UpdateScoreWindow(int earnedScore, int currentScore); // Обновление представления о количестве очков у игрока
    }
}