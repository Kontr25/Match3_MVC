using Slot;

namespace Tile
{
    public abstract class TileControllerAbstract
    {
        protected TileModelAbstract _model;
        protected TileViewAbstract _view;
        
        public abstract int ID { get; }

        protected TileControllerAbstract(TileModelAbstract model, TileViewAbstract view)
        {
            _model = model;
            _view = view;
            
        }
        public abstract void SetSlot(SlotControllerAbstract slotController); // Метод, устанавливающий слот, в который был помещен данный слот
        public abstract void SetRandomType(); // Метод, устанавливающий рандомный тип тайла (смена индекса от 0 до максимально возможного)
        protected abstract void Enable(); // Метод, активирующий слот
        public abstract void Disable(); // Метод, деактивирующий тайл
        public abstract bool IsActive(); // Метод, возвращающий true - если объект активирован, false - если деактивирован
        public abstract bool IsPropertiesEqual(int row, int column); // Метод, возвращающий результат сравнения входных координат с данными координат текущего тайла
    }
}