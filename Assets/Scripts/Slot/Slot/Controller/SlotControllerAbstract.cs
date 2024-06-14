using System;
using Interfaces;
using Tile;
using UnityEngine;

namespace Slot
{
    public abstract class SlotControllerAbstract : IDisposable, ISubscribable
    {
        public abstract event Action<SlotControllerAbstract> OnSlotClick; // Событие, вызываемое при клике на слот
        public abstract bool IsFree { get; }
        public abstract Vector2 Position { get; }
        public abstract int Row { get; }
        public abstract int Column { get; }
        public abstract int CurrentID { get; }

        protected SlotModelAbstract _model;
        protected SlotViewAbstract _view;

        protected SlotControllerAbstract(SlotModelAbstract model, SlotViewAbstract view)
        {
            _model = model;
            _view = view;
        }

        public abstract void Dispose(); // Освобождение ресурсов
        public abstract void Subscribe(); // Подписки
        public abstract void Unsubscribe(); // Отписки
        public abstract void HandleClick(); // Обработка клика по слоту
        public abstract void SetSlotCoordinates(int row, int column); // Метод записывающий данные о позиции слота в игровой сетке
        public abstract void SetTile(TileControllerAbstract tile); // Метод устанавливающий данные тайла помещенного в текущий слот
        public abstract void RemoveTile(); // Метод освобождающий текущий слот
        public abstract void SetOccupancy(bool isFree); // Метод для установки занятости слота.
    }
}