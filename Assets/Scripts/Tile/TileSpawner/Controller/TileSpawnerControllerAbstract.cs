namespace Tile
{
    public abstract class TileSpawnerControllerAbstract
    {
        protected TileSpawnerModelAbstract _model;
        protected TileSpawnerViewAbstract _view;

        protected TileSpawnerControllerAbstract(TileSpawnerModelAbstract model, TileSpawnerViewAbstract view)
        {
            _model = model;
            _view = view;
        }
        public abstract TileControllerAbstract GetSpawnedTile(); // Метод, возвращающий заспавненный тайл
    }
}