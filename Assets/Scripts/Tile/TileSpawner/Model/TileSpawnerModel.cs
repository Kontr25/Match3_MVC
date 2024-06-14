namespace Tile
{
    public class TileSpawnerModel: TileSpawnerModelAbstract
    {
        public override void TileDefaultParameters(TileControllerAbstract tileController)
        {
            tileController.Disable();
        }
    }
}