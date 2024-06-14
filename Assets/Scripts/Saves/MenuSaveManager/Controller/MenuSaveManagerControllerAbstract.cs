using System.Collections.Generic;

namespace Saves.MenuSaveManager
{
    public abstract class MenuSaveManagerControllerAbstract
    {
        /// <summary>
        /// Управляет взаимодействием между моделью сохранения игры и представлением.
        /// Отвечает за обновление окна рекордов и очистку сохранений
        /// </summary>
        
        protected MenuSaveManagerModelAbstract _model;
        protected MenuSaveManagerViewAbstract _view;

        protected MenuSaveManagerControllerAbstract(MenuSaveManagerModelAbstract model, MenuSaveManagerViewAbstract view)
        {
            _model = model;
            _view = view;
        }

        public abstract void LoadData(); // Загрузка сохранений
        public abstract List<string> GetPlayerNames(); // Возвращает список имен рекордсменов из хранилища
        public abstract List<int> GetRecordScores(); // Возвращает список рекордов из хранилища
        public abstract void AddPlayer(string playerName, int score); // Добавляет данные нового игрока в список рекордсменов
        public abstract void Dispose(); // Освобождение ресурсов
        public abstract void Subscribe(); // Подписки
        public abstract void Unsubscribe(); // Отписки
    }
}