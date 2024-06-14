namespace Tile
{
    public abstract class TileModelAbstract
    {
        protected int _row;
        protected int _column;
        protected int _id;
        protected bool _isActive;
        protected int _maxTypeID;
        public int ID => _id;
        public bool IsActive => _isActive;

        public abstract void
            SetSlotCoordinates(int row,
                int column); // Метод, устанавливающий координаты слота, в который был помещен данный тайл

        public abstract void
            SetRandomType(); // Метод, устанавливающий рандомный тип тайла (смена индекса от 0 до максимально возможного)

        public abstract void SetMaxTypeID(int id); // Метод, устанавливающий максимально возможное количество типо слота
        public abstract void SetActive(bool isActive); // Метод, активирующий или деактивирующий данный слот

        public abstract bool
            IsPropertiesEqual(int row, int column); // Метод, возвращающий результат сравнения входных координат
                                                    // с данными координат текущего тайла
    }
}