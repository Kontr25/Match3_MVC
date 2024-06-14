using System;
using System.Collections.Generic;
using Slot;

namespace TileSlotManager
{
    public class TileSlotDestroyer
    {
        /// <summary>
        /// Класс отвечающий за уничтожение тайла и всех одноцветных с ним тайлов, которые соприкасаются с ним по горизонтали и вертикали
        /// </summary>
        public event Action<int> OnDestructionComplete; // Событие, вызываемое по завершению уничтожения всех одноцветных соприкасающихся друг с другом тайлов

        private List<SlotControllerAbstract> _destroyedSlotModels = new List<SlotControllerAbstract>(); // Список уничтоженных слотов
        private TileSlotManagerControllerAbstract _tileSlotManagerController;
        private int _maxRows;
        private int _maxColumns;

        public TileSlotDestroyer(TileSlotManagerControllerAbstract tileSlotManagerController)
        {
            _tileSlotManagerController = tileSlotManagerController;
            _maxRows = _tileSlotManagerController.RowsCount;
            _maxColumns = _tileSlotManagerController.ColunsCount;
        }

        public void StartDestroyTiles(SlotControllerAbstract slot) // Метод, активирующий уничтожение тайлов
        {
            TryDestroyTile(slot);
            DestructionCompleted();
        }

        private void TryDestroyTile(SlotControllerAbstract slot) // Метод, уничтожающий конкретный тайл а так же пытающийся реверсивно
                                                                 // уничтожить всех соприкосающихся с ним соседей по вертикали и горизонтали
        {
            if (!_destroyedSlotModels.Contains(slot))
            {
                _destroyedSlotModels.Add(slot);
                _tileSlotManagerController.DestroyTileInSlot(slot);
                
                CheckAndDestroyNeighbor(slot.Row - 1, slot.Column, slot.CurrentID);
                CheckAndDestroyNeighbor(slot.Row + 1, slot.Column, slot.CurrentID);
                CheckAndDestroyNeighbor(slot.Row, slot.Column - 1, slot.CurrentID);
                CheckAndDestroyNeighbor(slot.Row, slot.Column + 1, slot.CurrentID);
            }
        }

        private void CheckAndDestroyNeighbor(int row, int column, int id) // Метод, пытающийся уничтожить конкретного соседнего тайла
        {
            if (row >= 0 && row < _maxRows && column >= 0 && column < _maxColumns)
            {
                SlotControllerAbstract neighborSlot = _tileSlotManagerController.GetSlotByProperties(row, column);
                if (neighborSlot.CurrentID == id && !_destroyedSlotModels.Contains(neighborSlot))
                {
                    TryDestroyTile(neighborSlot);
                }
            }
        }
        
        private void DestructionCompleted() // Метод, вызываемый по завершению уничтожения всех одноцветных соприкасающихся друг с другом тайлов
        {
            OnDestructionComplete?.Invoke(_destroyedSlotModels.Count);
        }
    }
}