using System;
using Utilities;

namespace Tile
{
    public abstract class TileManagerModelAbstract
    {
        public abstract event Action OnTileRequestEmpty; // Событие, вызываемое если в пуле тайлов нет свободных неактивных тайлов
        
        protected Pool<TileControllerAbstract> _tilePool = new Pool<TileControllerAbstract>(); // Пул тайлов
        public abstract void AddTileToPool(TileControllerAbstract tile); // Метод, добавляющий тайл в пул
        public abstract TileControllerAbstract GetFreeTile(); // Метод, возвращающий неактивный свободный тайл из пула, если таковой имеется
                                                              // и спавнящий и возвращающий новый тайл если такого в пуле нет
        public abstract TileControllerAbstract GetTileByProperties(int row, int column); // Метод, возвращающий конкретный тайл
    }
}