using Slot;
using Tile;

namespace TileSlotManager
{
    public abstract class TileSlotManagerModelAbstract
    {
        public abstract void SetTileInSlot(TileControllerAbstract tile, SlotControllerAbstract slot); // Метод, устанавливающий конкретный тайл в конкретный слот
        public abstract void DestroyTileInSlot(TileControllerAbstract tile, SlotControllerAbstract slot); // Метод, уничтожающий кокретный тайл в конкретном слоте
    }
}