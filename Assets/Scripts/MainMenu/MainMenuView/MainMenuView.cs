using System;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuView: MainMenuViewAbstract
    {
        public override event Action OnStartGameButtonClick;
        public override event Action OnQuitButtonClick;

        [SerializeField] private GameObject _recordWindow;

        public override void HandleStartGameButtonClick()
        {
            OnStartGameButtonClick?.Invoke();
        }

        public override void HandleRecordButtonClick()
        {
            OpenRecordWindow();
        }

        public override void HandleQuitButtonClick()
        {
            OnQuitButtonClick?.Invoke();
        }

        public override void HandleCloseRecordButtonClick()
        {
            CloseRecordWindow();
        }

        public override void OpenRecordWindow()
        {
            _recordWindow.SetActive(true);
        }

        public override void CloseRecordWindow()
        {
            _recordWindow.SetActive(false);
        }

        public override void Subscribe()
        {
            _startGameButton.onClick.AddListener(HandleStartGameButtonClick);
            _recordButton.onClick.AddListener(HandleRecordButtonClick);
            _quitButton.onClick.AddListener(HandleQuitButtonClick);
            _closeRecordButton.onClick.AddListener(HandleCloseRecordButtonClick);
        }

        public override void Unsubscribe()
        {
            _startGameButton.onClick.RemoveListener(HandleStartGameButtonClick);
            _recordButton.onClick.RemoveListener(HandleRecordButtonClick);
            _quitButton.onClick.RemoveListener(HandleQuitButtonClick);
            _closeRecordButton.onClick.RemoveListener(HandleCloseRecordButtonClick);
        }
    }
}