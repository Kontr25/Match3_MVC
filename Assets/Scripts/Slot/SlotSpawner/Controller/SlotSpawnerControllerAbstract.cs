namespace Slot
{
    public abstract class SlotSpawnerControllerAbstract
    {
        protected SlotSpawnerModelAbstract _model;
        protected SlotSpawnerViewAbstract _view;

        protected SlotSpawnerControllerAbstract(SlotSpawnerModelAbstract model, SlotSpawnerViewAbstract view, int columnsCount)
        {
            _model = model;
            _view = view;
        }
        
        public abstract SlotControllerAbstract GetSpawnedSlot(); // Метод, создающий и возвращающий контроллер слота
        public abstract void UpdateCanvas(); // Метод, принудительно обновляющий все канвасы в игре, чтобы гарантировать корректное отображение изменений

    }
}