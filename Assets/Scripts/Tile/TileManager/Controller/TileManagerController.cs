namespace Tile
{
    public class TileManagerController : TileManagerControllerAbstract
    {
        public TileManagerController(TileManagerModelAbstract model, TileManagerViewAbstract view, TileSpawnerControllerAbstract tileSpawnerController, int rowsCount, int columnsCount) : base(model, view, tileSpawnerController, rowsCount, columnsCount)
        {
            int tileCount = rowsCount * columnsCount;
            Subscribe();
            SpawnTiles(tileCount);
        }
        
        public override void Subscribe()
        {
            _model.OnTileRequestEmpty += HandleTileRequestEmpty;
        }

        public override void Unsubscribe()
        {
            _model.OnTileRequestEmpty -= HandleTileRequestEmpty;
        }

        public override void Dispose()
        {
            Unsubscribe();
        }

        protected override void SpawnTiles(int tileCount)
        {
            for (int i = 0; i < tileCount; i++)
            {
                AddTileToPool(_tileSpawnerController.GetSpawnedTile());
            }
        }

        protected override void HandleTileRequestEmpty()
        {
            SpawnTiles(1);
        }

        public override void AddTileToPool(TileControllerAbstract tile)
        {
            _model.AddTileToPool(tile);
        }

        public override TileControllerAbstract GetFreeTile()
        {
            return _model.GetFreeTile();
        }

        public override TileControllerAbstract GetTileByProperties(int row, int column)
        {
            return _model.GetTileByProperties(row, column);
        }

    }
}