using System;
using Interfaces;

namespace ScoreManager
{
    public abstract class ScoreManagerControllerAbstract: IDisposable, ISubscribable
    {
        public abstract event Action<int> OnGameOver; // Событие, которое вызывается когда у игрока заканчиваются очки
        
        protected ScoreManagerModelAbstract _model;
        protected ScoreManagerViewAbstract _view;

        protected ScoreManagerControllerAbstract(ScoreManagerModelAbstract model, ScoreManagerViewAbstract view)
        {
            _model = model;
            _view = view;
        }
        
        public abstract void HandleTileDestruction(int numberOfDestroyedTiles); // Обрабатывает количество уничтоженных тайлов
        public abstract void GameOver(int score); // Метод, вызывающий событие OnGameOver
        public abstract void Dispose(); // Освобождение ресурсов
        public abstract void Subscribe(); // Подписки
        public abstract void Unsubscribe(); // Отписки
    }
}