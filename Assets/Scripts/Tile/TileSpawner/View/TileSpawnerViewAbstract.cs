using UnityEngine;

namespace Tile
{
    public abstract class TileSpawnerViewAbstract: MonoBehaviour
    {
        public abstract TileViewAbstract CreateAndReturnTileView(); // Метод, создающий и возвращающий вью тайла
    }
}