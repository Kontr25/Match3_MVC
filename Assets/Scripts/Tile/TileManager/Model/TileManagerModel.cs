using System;

namespace Tile
{
    public class TileManagerModel: TileManagerModelAbstract
    {
        public override event Action OnTileRequestEmpty;

        public override void AddTileToPool(TileControllerAbstract tile)
        {
            _tilePool.AddToPool(tile);
        }

        public override TileControllerAbstract GetFreeTile()
        {
            TileControllerAbstract tile = _tilePool.GetFreeItem(t => t.IsActive());

            if (tile != null)
            {
                tile.SetRandomType();
                return tile;
            }

            OnTileRequestEmpty?.Invoke();
            return GetFreeTile();
        }

        public override TileControllerAbstract GetTileByProperties(int row, int column)
        {
            return _tilePool.GetItemByProperties(t => t.IsPropertiesEqual(row, column));
        }
    }
}