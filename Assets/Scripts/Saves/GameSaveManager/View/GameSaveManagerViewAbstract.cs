using System;
using UnityEngine;

namespace Saves.GameSaveManager
{
    public abstract class GameSaveManagerViewAbstract: MonoBehaviour
    {
        public abstract event Action<string, int> OnSaveNewRecord; // Событие, вызываемое после успешного ввода данных игрока и нажатии на кнопку сохранения
        public abstract void EnableNewRecordWindow(int score); // Активация окна для записи нового рекорда
        public abstract void EnableGameOverWindow(int score); // Активация окна завершения игры
        public abstract void SaveNewRecord(); // Попытка сохранить данные игрока (вызывается при нажатии на кнопку сохранения данных)
    }
}