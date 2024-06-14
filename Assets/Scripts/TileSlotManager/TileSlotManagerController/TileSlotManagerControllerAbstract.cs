using System;
using Interfaces;
using Slot;
using Tile;

namespace TileSlotManager
{
    public abstract class TileSlotManagerControllerAbstract: IDisposable, ISubscribable
    {
        public abstract event Action<int> OnDestructionComplete; // Событие, вызываемое по завершению уничтожения всех одноцветных соприкасающихся друг с другом тайлов
        protected TileSlotManagerModelAbstract _model;
        protected TileSlotManagerViewAbstract _view;
        
        protected TileManagerControllerAbstract _tileManagerController;
        protected SlotManagerControllerAbstract _slotManagerController;

        protected int _rowsCount;
        protected int _columnsCount;
        public int RowsCount => _rowsCount;
        public int ColunsCount => _columnsCount;

        protected TileSlotManagerControllerAbstract(TileSlotManagerModelAbstract model, TileSlotManagerViewAbstract view, 
            TileManagerControllerAbstract tileManagerController, SlotManagerControllerAbstract slotManagerController, 
            int rowsCount, int columnsCount)
        {
            _model = model;
            _view = view;
            _tileManagerController = tileManagerController;
            _slotManagerController = slotManagerController;
            _rowsCount = rowsCount;
            _columnsCount = columnsCount;
        }


        public abstract void Dispose(); // Освобождение ресурсов
        public abstract void Subscribe(); // Подписки
        public abstract void Unsubscribe(); // Отписки
        public abstract void SetAllTileInSlot(); // Метод, заполняющий слоты тайлами
        public abstract void SetTileInSlot(TileControllerAbstract tile, SlotControllerAbstract slot); // Метод, устанавливающий конкретный тайл в конкретный слот
        public abstract void HandleTileDestruction(int numberOfDestroyedTiles); // Метод, обрабатывающий количество уничтоженных тайлов
        public abstract void DestroyTileInSlot(SlotControllerAbstract slot); // Метод, уничтожающий конкретный тайл в конкретном слоте
        public abstract void OnSlotClicked(SlotControllerAbstract slot); // Метод, обрабатывающий клик по конкретному слоту
        public abstract SlotControllerAbstract GetSlotByProperties(int row, int column); // Метод, возвращающий конкретный слот
        public abstract TileControllerAbstract GetTileByProperties(int row, int column); // Метод, возвращающий конкретный тайл
        public abstract TileControllerAbstract GetFreeTile(); // Метод, возвращающий свободный неактивный тайл
    }
}