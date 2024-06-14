namespace Slot
{
    public abstract class SlotModelAbstract
    {
        protected int _row; // Номер строки в которой находится слот
        protected int _column; // Номер столбца в которой находится слот
        protected bool _isFree; // Переменная, указывающая, свободен ли слот
        protected int _currentID; // ID текучего тайла внтури слота
        
        public int Row => _row;
        public int Column => _column;
        public bool IsFree => _isFree;
        public int CurrentID => _currentID;

        public abstract void SetSlotCoordinates(int row, int column); // Метод записывающий данные о позиции слота в игровой сетке
        public abstract void SetTile(int id); // Метод устанавливающий данные тайла помещенного в текущий слот
        public abstract void SetOccupancy(bool isFree); // Метод для установки занятости слота.
    }
}