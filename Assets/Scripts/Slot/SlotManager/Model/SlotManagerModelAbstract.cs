namespace Slot
{
    public abstract class SlotManagerModelAbstract
    {
        protected SlotControllerAbstract[,] _gridSlots; // Двумерный массив, хранящий все контроллеры слотов по их координатам в игровой сетке

        protected SlotManagerModelAbstract(int rowsCount, int columnsCount)
        {
            _gridSlots = new SlotControllerAbstract[rowsCount, columnsCount];
        }

        public abstract SlotControllerAbstract[,] GridSlots { get; }

        public abstract void AddSlotOnGrid(SlotControllerAbstract slotController, int row, int column); // Метод для добавления слота в игровую сетку
        public abstract SlotControllerAbstract GetSlotByProperties(int row, int column); // Метод, возвращающий определенный контроллер слота
    }
}