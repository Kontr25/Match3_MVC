using System;
using Interfaces;

namespace MainMenu
{
    public abstract class MainMenuControllerAbstract: IDisposable, ISubscribable
    {
        /// <summary>
        /// Управляет взаимодействием между моделью и представлением главного меню.
        /// </summary>
        
        protected MainMenuModelAbstract _model;
        protected MainMenuViewAbstract _view;

        protected MainMenuControllerAbstract(MainMenuModelAbstract model, MainMenuViewAbstract view)
        {
            _model = model;
            _view = view;
        }

        public abstract void Dispose(); // Освобождение ресурсов
        public abstract void Subscribe(); // Подписки на события
        public abstract void Unsubscribe();// Отписки от событий
    }
}