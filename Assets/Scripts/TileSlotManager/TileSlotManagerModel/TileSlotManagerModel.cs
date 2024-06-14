using Slot;
using Tile;

namespace TileSlotManager
{
    public class TileSlotManagerModel: TileSlotManagerModelAbstract
    {
        public override void SetTileInSlot(TileControllerAbstract tile, SlotControllerAbstract slot) 
        {
            tile.SetSlot(slot);
            slot.SetTile(tile);
        }

        public override void DestroyTileInSlot(TileControllerAbstract tile, SlotControllerAbstract slot)
        {
            tile.Disable();
            slot.RemoveTile();
        }
    }
}