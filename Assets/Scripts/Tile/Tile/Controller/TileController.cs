using Slot;

namespace Tile
{
    public class TileController: TileControllerAbstract
    {
        public TileController(TileModelAbstract model, TileViewAbstract view) : base(model, view)
        {
            _model.SetMaxTypeID(_view.MaxTypeID());
        }

        public override int ID => _model.ID;

        public override void SetSlot(SlotControllerAbstract slotController)
        {
            _view.SetAnchoredPosition(slotController.Position);
            _model.SetSlotCoordinates(slotController.Row, slotController.Column);
            Enable();
        }

        public override void SetRandomType()
        {
            _model.SetRandomType();
            _view.UpdateVisuals(_model.ID);
        }

        protected override void Enable()
        {
            _model.SetActive(true);
            _view.Enable();
        }

        public override void Disable()
        {
            _model.SetActive(false);
            _view.Disable();
        }

        public override bool IsActive()
        {
            return _model.IsActive;
        }

        public override bool IsPropertiesEqual(int row, int column)
        {
            return _model.IsPropertiesEqual(row, column);
        }
    }
}