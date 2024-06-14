using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Saves.MenuSaveManager
{
    public abstract class MenuSaveManagerViewAbstract: MonoBehaviour, ISubscribable
    {
        public abstract event Action OnClearSaves; 
        
        [SerializeField] protected string[] _randomNames; // Список рандомных имен для фейковых рекордсменов
        public abstract string[] RandomNames { get; }
        public abstract int FirstPlaceCount { get; }
        public abstract void UpdateRecordWindow(List<string> playerNames, List<int> playerRecords); // Обновление окна рекордов
        public abstract void ClearSaves(); // Удаление сохранений
        public abstract void Subscribe(); // Подписки
        public abstract void Unsubscribe(); // Отписки
    }
}