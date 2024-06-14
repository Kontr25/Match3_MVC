namespace Slot
{
    public class SlotModel: SlotModelAbstract
    {
        public override void SetSlotCoordinates(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public override void SetTile(int id)
        {
            _currentID = id;
            _isFree = false;
        }

        public override void SetOccupancy(bool isFree)
        {
            _isFree = isFree;
        }
    }
}