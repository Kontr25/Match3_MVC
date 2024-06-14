namespace Tile
{
    public class TileSpawnerController: TileSpawnerControllerAbstract
    {
        public TileSpawnerController(TileSpawnerModelAbstract model, TileSpawnerViewAbstract view) : base(model, view)
        {
            
        }

        public override TileControllerAbstract GetSpawnedTile()
        {
            TileModel tileModel = new TileModel();
            TileController tileController = new TileController(tileModel, _view.CreateAndReturnTileView());
            _model.TileDefaultParameters(tileController);
            return tileController;
        }
    }
}