namespace Saves.GameSaveManager
{
    public abstract class GameSaveManagerControllerAbstract
    {
        /// <summary>
        /// Управляет взаимодействием между моделью сохранения игры и представлением.
        /// Отвечает за добавление новых рекордсменов
        /// </summary>
        protected GameSaveManagerModelAbstract _model;
        protected GameSaveManagerViewAbstract _view;

        protected GameSaveManagerControllerAbstract(GameSaveManagerModelAbstract model, GameSaveManagerViewAbstract view)
        {
            _model = model;
            _view = view;
        }

        public abstract void AddPlayer(string playerName, int score); // Добавляет данные нового игрока в список рекордсменов
        public abstract void TrySaveNewRecord(int score); // Сохранение рекорда, если рекорд попадает в тройку рекордсменов
        public abstract void Dispose(); // Освобождение ресурсов
        public abstract void Subscribe(); // Подписки
        public abstract void Unsubscribe(); // Отписки
    }
}