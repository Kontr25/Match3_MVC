namespace Slot
{
    public class SlotSpawnerModel: SlotSpawnerModelAbstract
    {
        public override void SlotDefaultParameters(SlotControllerAbstract slotController)
        {
            slotController.SetOccupancy(true);
        }
    }
}