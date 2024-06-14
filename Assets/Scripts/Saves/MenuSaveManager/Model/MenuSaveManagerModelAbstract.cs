using System;
using System.Collections.Generic;

namespace Saves.MenuSaveManager
{
    public abstract class MenuSaveManagerModelAbstract
    {
        public abstract event Action<List<string>, List<int>> OnSavesUpdate; // Событие, вызываемое при обновлении сохранений
        public abstract event Action OnClearSaves; // Событие, вызываемое при удалении сохранений
        
        protected Storage _storage;
        protected SavesData _savesData;
        protected int _firstPlaceCount; // Количество мест в списке для рекордсмено

        protected MenuSaveManagerModelAbstract()
        {
            // Инициализация хранилища
            _storage = new Storage();
        }

        public abstract void LoadData(string[] randomNames); // Загрузка сохранений
        public abstract void SetFirstPlaceCount(int firstPlaceCount); // Инициализация количество мест в списке для рекордсмено
        public abstract List<string> GetPlayerNames(); // Возвращает список имен рекордсменов из хранилища
        public abstract List<int> GetRecordScores(); // Возвращает список рекордов из хранилища
        public abstract void AddPlayer(string playerName, int score); // Добавляет данные нового игрока в список рекордсменов
        protected abstract void Save(); // Метод перезаписи сохранений
        public abstract void ClearSaves(); // Метод полного удаления всех сохранений
    }
}