using TMPro;
using UnityEngine;

namespace ScoreManager
{
    public class ScoreManagerView: ScoreManagerViewAbstract
    {
        [SerializeField] private TMP_Text _earnedScoreText;
        [SerializeField] private TMP_Text _currentScoreText;
        
        public override void UpdateScoreWindow(int earnedScore, int currentScore)
        {
            _earnedScoreText.text =$"SCORE EARNED: {earnedScore.ToString()}";
            _currentScoreText.text = $"CURRENT SCORE: {currentScore.ToString()}";
        }
    }
}