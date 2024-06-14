namespace Slot
{
    public class SlotManagerController: SlotManagerControllerAbstract
    {
        public SlotManagerController(SlotManagerModelAbstract model, SlotManagerViewAbstract view, SlotSpawnerControllerAbstract slotSpawnerController, int rowsCount, int columnsCount) : base(model, view, slotSpawnerController, rowsCount, columnsCount)
        {
            SpawnSlots();
        }
        
        public override void SpawnSlots()
        {
            for (int row = 0; row < _rowsCount; row++)
            {
                for (int column = 0; column < _columnsCount; column++)
                {
                    SlotControllerAbstract slotController = _slotSpawnerController.GetSpawnedSlot();
                    _model.AddSlotOnGrid(slotController, row, column);
                }
            }
            _slotSpawnerController.UpdateCanvas();
        }

        public override SlotControllerAbstract GetSlotByProperties(int row, int column)
        {
            return _model.GetSlotByProperties(row, column);
        }

    }
}