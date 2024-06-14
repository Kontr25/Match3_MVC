namespace Slot
{
    public class SlotSpawnerController: SlotSpawnerControllerAbstract
    {
        public SlotSpawnerController(SlotSpawnerModelAbstract model, SlotSpawnerViewAbstract view, int columnsCount) : base(model, view, columnsCount)
        {
            _view.SetGridColumnSize(columnsCount);
        }
        
        public override SlotControllerAbstract GetSpawnedSlot()
        {
            SlotModel slotModel = new SlotModel();
            SlotView slotView = _view.CreateAndReturnSlot();
            SlotController slotController = new SlotController(slotModel, slotView);
            _model.SlotDefaultParameters(slotController);
            return slotController;
        }

        public override void UpdateCanvas()
        {
            _view.UpdateCanvas();
        }

    }
}