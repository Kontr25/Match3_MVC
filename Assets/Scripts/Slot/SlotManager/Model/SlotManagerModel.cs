namespace Slot
{
    public class SlotManagerModel: SlotManagerModelAbstract
    {
        public SlotManagerModel(int rowsCount, int columnsCount) : base(rowsCount, columnsCount)
        {
            
        }
        public override SlotControllerAbstract[,] GridSlots => _gridSlots;

        public override void AddSlotOnGrid(SlotControllerAbstract slotController, int row, int column)
        {
            slotController.SetSlotCoordinates(row, column);
            GridSlots[row, column] = slotController;
        }

        public override SlotControllerAbstract GetSlotByProperties(int row, int column)
        {
            return GridSlots[row, column];
        }
    }
}