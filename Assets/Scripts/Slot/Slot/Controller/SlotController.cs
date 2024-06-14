using System;
using Tile;
using UnityEngine;

namespace Slot
{
    public class SlotController: SlotControllerAbstract
    {
        public override event Action<SlotControllerAbstract> OnSlotClick;
        public SlotController(SlotModelAbstract model, SlotViewAbstract view) : base(model, view)
        {
            Subscribe();
        }

        public override bool IsFree => _model.IsFree;
        public override Vector2 Position => _view.AnchoredPosition;
        public override int Row => _model.Row;
        public override int CurrentID => _model.CurrentID;
        public override int Column => _model.Column;

        public override void Dispose()
        {
            Unsubscribe();
        }

        public override void Subscribe()
        {
            _view.OnSlotClick += HandleClick;
            _view.Subscribe();
        }

        public override void Unsubscribe()
        {
            _view.OnSlotClick -= HandleClick;
            _view.Unsubscribe();
        }

        public override void HandleClick()
        {
            _model.SetOccupancy(false);
            OnSlotClick?.Invoke(this);
        }

        public override void SetSlotCoordinates(int row, int column)
        {
            _model.SetSlotCoordinates(row, column);
        }

        public override void SetTile(TileControllerAbstract tile)
        {
            _model.SetTile(tile.ID);
            _model.SetOccupancy(false);
        }

        public override void RemoveTile()
        {
            SetOccupancy(true);
        }

        public override void SetOccupancy(bool isFree)
        {
            _model.SetOccupancy(isFree);
        }
    }
}