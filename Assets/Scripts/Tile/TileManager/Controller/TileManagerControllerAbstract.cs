using System;
using Interfaces;

namespace Tile
{
    public abstract class TileManagerControllerAbstract: IDisposable, ISubscribable
    {
        protected TileManagerModelAbstract _model;
        protected TileManagerViewAbstract _view;
        protected TileSpawnerControllerAbstract _tileSpawnerController;
        
        protected TileManagerControllerAbstract(TileManagerModelAbstract model, TileManagerViewAbstract view, 
        TileSpawnerControllerAbstract tileSpawnerController, int rowsCount, int columnsCount)
        {
            _model = model;
            _view = view;
            _tileSpawnerController = tileSpawnerController;
        }

        public abstract void Subscribe(); // Подписки
        public abstract void Unsubscribe(); // Отписки
        public abstract void Dispose(); // Освобождение ресурсов
        protected abstract void SpawnTiles(int tileCount); // Метод, спавнящий определенное количество тайлов
        protected abstract void HandleTileRequestEmpty(); // Метод, вызываемый в тот момент, когда в пуле нет свободных неактивных тайлов
        public abstract void AddTileToPool(TileControllerAbstract tile); // Метод, добавляющий тайл в пул
        public abstract TileControllerAbstract GetFreeTile(); // Метод, возвращающий неактивный свободный тайл из пула, если таковой имеется
                                                              // и спавнящий и возвращающий новый тайл если такого в пуле нет
        public abstract TileControllerAbstract GetTileByProperties(int row, int column); // Метод, возвращающий конкретный тайл

    }
}