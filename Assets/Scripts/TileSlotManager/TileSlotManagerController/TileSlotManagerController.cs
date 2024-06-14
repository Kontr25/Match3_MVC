using System;
using Slot;
using Tile;

namespace TileSlotManager
{
    public class TileSlotManagerController: TileSlotManagerControllerAbstract
    {
        public override event Action<int> OnDestructionComplete;
        
        private TileSlotFiller _tileSlotFiller;
        private TileSlotDestroyer _currentTileSlotDestroyer;
        public TileSlotManagerController(TileSlotManagerModelAbstract model, TileSlotManagerViewAbstract view, TileManagerControllerAbstract tileManagerController, SlotManagerControllerAbstract slotManagerController, int rowsCount, int columnsCount) : base(model, view, tileManagerController, slotManagerController, rowsCount, columnsCount)
        {
            _tileSlotFiller = new TileSlotFiller(this);
            Subscribe();
        }
        
        public override void OnSlotClicked(SlotControllerAbstract slot)
        {
            _currentTileSlotDestroyer = new TileSlotDestroyer(this);
            _currentTileSlotDestroyer.OnDestructionComplete += HandleTileDestruction;
            _currentTileSlotDestroyer.StartDestroyTiles(slot);
        }


        public override void Dispose()
        {
            Unsubscribe();
        }

        public override void Subscribe()
        {
            for (int row = 0; row < RowsCount; row++)
            {
                for (int column = 0; column < _columnsCount; column++)
                {
                    _slotManagerController.GetSlotByProperties(row, column).OnSlotClick += OnSlotClicked;
                }
            }
        }

        public override void Unsubscribe()
        {
            for (int row = 0; row < RowsCount; row++)
            {
                for (int column = 0; column < _columnsCount; column++)
                {
                    _slotManagerController.GetSlotByProperties(row, column).OnSlotClick -= OnSlotClicked;
                }
            }
        }

        public override void SetAllTileInSlot()
        {
            for (int row = 0; row < RowsCount; row++)
            {
                for (int column = 0; column < _columnsCount; column++)
                {
                    TileControllerAbstract tile = _tileManagerController.GetFreeTile();
                    SlotControllerAbstract slot = _slotManagerController.GetSlotByProperties(row, column);
                    SetTileInSlot(tile, slot);
                }
            }
        }

        public override void SetTileInSlot(TileControllerAbstract tile, SlotControllerAbstract slot)
        {
            _model.SetTileInSlot(tile, slot);
        }

        public override void HandleTileDestruction(int numberOfDestroyedTiles)
        {
            _currentTileSlotDestroyer.OnDestructionComplete -= HandleTileDestruction;
            OnDestructionComplete?.Invoke(numberOfDestroyedTiles);
            _currentTileSlotDestroyer = null;
            _tileSlotFiller.FillSlots();
        }

        public override void DestroyTileInSlot(SlotControllerAbstract slot)
        {
            TileControllerAbstract tile = _tileManagerController.GetTileByProperties(slot.Row, slot.Column);
            _model.DestroyTileInSlot(tile, slot);
        }
        
        public override SlotControllerAbstract GetSlotByProperties(int row, int column)
        {
            return _slotManagerController.GetSlotByProperties(row, column);
        }

        public override TileControllerAbstract GetTileByProperties(int row, int column)
        {
            return _tileManagerController.GetTileByProperties(row, column);
        }

        public override TileControllerAbstract GetFreeTile()
        {
            return _tileManagerController.GetFreeTile();
        }

    }
}