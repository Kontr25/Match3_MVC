using System;
using UnityEngine;

namespace Slot
{
    public class SlotView: SlotViewAbstract
    {
        public override event Action OnSlotClick;
        public override Vector2 AnchoredPosition  => _slotRectTransform.anchoredPosition;

        public override void HandleSlotButtonClick()
        {
            OnSlotClick?.Invoke();
        }

        public override void Subscribe()
        {
            _slotButton.onClick.AddListener(HandleSlotButtonClick);
        }

        public override void Unsubscribe()
        {
            _slotButton.onClick.RemoveListener(HandleSlotButtonClick);
        }
    }
}