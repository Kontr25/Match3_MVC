using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Saves.GameSaveManager
{
    public class GameSaveManagerView: GameSaveManagerViewAbstract
    {
        public override event Action<string, int> OnSaveNewRecord;
        
        [SerializeField] private GameObject _saveNewRecordWindow;
        [SerializeField] private TMP_Text _recordText;
        [SerializeField] private TMP_Text _errorText;
        [SerializeField] private Button _saveRecordButton;
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private GameObject _gameOverWindow;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        private int _scoreToSave;
        private void Start()
        {
            Subscribe();
        }

        public override void EnableNewRecordWindow(int score)
        {
            _scoreToSave = score;
            _recordText.text = $"YOUR RECORD: {score}";
            _saveNewRecordWindow.SetActive(true);
        }

        public override void EnableGameOverWindow(int score)
        {
            _scoreText.text = $"score: {score}";
            _gameOverWindow.SetActive(true);
        }

        private void Restart()
        {
            SceneManager.LoadScene(1);
        }
        
        private void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public override void SaveNewRecord()
        {
            string text = _nameInputField.text;

            if (string.IsNullOrEmpty(text))
            {
                _errorText.gameObject.SetActive(true);
                _errorText.text = "Введите ваше имя";
            }
            else
            {
                if(_errorText.gameObject.activeInHierarchy) _errorText.gameObject.SetActive(false);
                _saveNewRecordWindow.SetActive(false);
                OnSaveNewRecord?.Invoke(_nameInputField.text, _scoreToSave);
                _saveNewRecordWindow.SetActive(false);
                EnableGameOverWindow(_scoreToSave);
            }
        }

        public void Subscribe()
        {
            _saveRecordButton.onClick.AddListener(SaveNewRecord);
            _restartButton.onClick.AddListener(Restart);
            _mainMenuButton.onClick.AddListener(LoadMainMenu);
        }

        public void Unsubscribe()
        {
            _saveRecordButton.onClick.RemoveListener(SaveNewRecord);
            _restartButton.onClick.RemoveListener(Restart);
            _mainMenuButton.onClick.RemoveListener(LoadMainMenu);
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}