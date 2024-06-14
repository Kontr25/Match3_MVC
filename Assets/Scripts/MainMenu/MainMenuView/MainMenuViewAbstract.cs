using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public abstract class MainMenuViewAbstract: MonoBehaviour, ISubscribable
    {
        public abstract event Action OnStartGameButtonClick; // Событие, вызываемое при нажатии кнопки старта игры
        public abstract event Action OnQuitButtonClick; // Событие, вызываемое при нажатии кнопки выхода из игры
        
        [SerializeField] protected Button _startGameButton;
        [SerializeField] protected Button _recordButton;
        [SerializeField] protected Button _quitButton;
        [SerializeField] protected Button _closeRecordButton;

        public abstract void HandleStartGameButtonClick(); // Обработка клика на кнопку старта игры
        public abstract void HandleRecordButtonClick(); // Обработка клика на кнопку рекордов
        public abstract void HandleQuitButtonClick(); // Обработка клика на кнопку выхода
        public abstract void HandleCloseRecordButtonClick(); // Обработка клика на кнопку закрытия окна рекордов
        public abstract void OpenRecordWindow(); // Открытие окна с рекордами
        public abstract void CloseRecordWindow(); // Закрытие окна с рекордами
        public abstract void Subscribe(); // Подписки
        public abstract void Unsubscribe(); // Отписки
    }
}