using Slot;
using Tile;

namespace TileSlotManager
{
    public class TileSlotFiller
    {
        /// <summary>
        /// Класс, отвечающий за заполнение пустых слотов тайлами
        /// </summary>
        private TileSlotManagerControllerAbstract _tileSlotManagerController;
        private int _maxRows;
        private int _maxColumns;

        public TileSlotFiller(TileSlotManagerControllerAbstract tileSlotManagerController)
        {
            _tileSlotManagerController = tileSlotManagerController;
            _maxRows = _tileSlotManagerController.RowsCount;
            _maxColumns = _tileSlotManagerController.ColunsCount;
        }

        // Метод, который пробегается по всем столбцам игровой сетки сверху вниз и заполняет пустые слоты
        public void FillSlots()
        {
            for (int column = 0; column < _maxColumns; column++)
            {
                for (int row = _maxRows - 1; row >= 0; row--)
                {
                    SlotControllerAbstract targetSlot = _tileSlotManagerController.GetSlotByProperties(row, column);

                    if (targetSlot.IsFree)
                    {
                        SlotControllerAbstract upSlot = TryGetUpSlot(row, column);

                        if (upSlot != null)
                        {
                            TileControllerAbstract tile = _tileSlotManagerController.GetTileByProperties(upSlot.Row, column);
                            upSlot.SetOccupancy(true);
                            targetSlot.SetOccupancy(false);
                            _tileSlotManagerController.SetTileInSlot(tile, targetSlot);
                        }
                        else
                        {
                            TileControllerAbstract tile = _tileSlotManagerController.GetFreeTile();
                            _tileSlotManagerController.SetTileInSlot(tile, targetSlot);
                        }
                    }
                }
            }
        }

    private SlotControllerAbstract TryGetUpSlot(int currentRow, int currentColumn) // Метод, возвращающий не пустой слот, если таковой имеется, если нет возвращает null
        {
            for (int row = currentRow - 1; row >= 0; row--)
            {
                if (!_tileSlotManagerController.GetSlotByProperties(row, currentColumn).IsFree)
                {
                    SlotControllerAbstract upSlot = _tileSlotManagerController.GetSlotByProperties(row, currentColumn);
                    return upSlot;
                }
            }

            return null;
        }
    }
}