namespace Slot
{
    public abstract class SlotManagerControllerAbstract
    {
        protected SlotManagerModelAbstract _model;
        protected SlotManagerViewAbstract _view;
        protected SlotSpawnerControllerAbstract _slotSpawnerController;
        protected int _rowsCount; // Данные о количестве строк в игровой сетке
        protected int _columnsCount; // Данные о количестве столбцов в игровой сетке

        protected SlotManagerControllerAbstract(SlotManagerModelAbstract model, SlotManagerViewAbstract view, 
            SlotSpawnerControllerAbstract slotSpawnerController , int rowsCount, int columnsCount)
        {
            _model = model;
            _view = view;
            _slotSpawnerController = slotSpawnerController;
            _rowsCount = rowsCount;
            _columnsCount = columnsCount;
        }
        
        public abstract void SpawnSlots(); // Метод спавна слотов на сетке
        public abstract SlotControllerAbstract GetSlotByProperties(int row, int column); // Метод, возвращающий определенный контроллер слота

    }
}