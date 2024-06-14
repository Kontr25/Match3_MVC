using UnityEngine;

namespace Tile
{
    public class TileModel: TileModelAbstract
    {
        public override void SetSlotCoordinates(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public override void SetRandomType()
        {
            _id = Random.Range(0, _maxTypeID);
        }

        public override void SetMaxTypeID(int id)
        {
            if (_id < 0)
            {
                _maxTypeID = 0;
                return;
            }

            _maxTypeID = id;
        }

        public override void SetActive(bool isActive)
        {
            _isActive = isActive;
        }

        public override bool IsPropertiesEqual(int row, int column)
        {
            return _row == row && _column == column;
        }
    }
}