using System;

namespace Saves.GameSaveManager
{
    public abstract class GameSaveManagerModelAbstract
    {
        public abstract event Action<int> OnSuccessfulComparison; // Событие, вызываемое при успешном сравнении с тройкой лидеров
        public abstract event Action<int> OnFailedComparison;// Событие, вызываемое при НЕ успешном сравнении с тройкой лидеров
        
        protected Storage _storage;
        protected SavesData _savesData;
        protected int _firstPlaceCount; // Количество мест в списке для рекордсмено

        protected GameSaveManagerModelAbstract()
        {
            // Инициализация хранилища
            _storage = new Storage(); 
            
            // Загрузка сохранений
            _savesData = (SavesData)_storage.Load(new SavesData());
            _firstPlaceCount = _savesData.FirstPlaceCount;
        }

        public abstract void AddPlayer(string playerName, int score); // Добавление данных игрока в список рекордсменов
        public abstract void CompareScoresWithTopThree(int score); // Сравнение данных игрока с тройкой лидеров
        protected abstract void Save(); // Метод перезаписи сохранений
    }
}