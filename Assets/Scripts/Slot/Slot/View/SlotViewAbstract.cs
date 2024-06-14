using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Slot
{
    public abstract class SlotViewAbstract: MonoBehaviour, ISubscribable
    {
        public abstract event Action OnSlotClick; // Событие, вызываемое при клике на слот
        
        [SerializeField] protected Button _slotButton;
        [SerializeField] protected RectTransform _slotRectTransform;
        
        public abstract Vector2 AnchoredPosition { get; }
        public abstract void HandleSlotButtonClick(); // Обработка клика по слоту
        public abstract void Subscribe(); // Подписки
        public abstract void Unsubscribe(); // Отписки
    }
}