using UnityEngine;
using UnityEngine.UI;

namespace Slot
{
    public class SlotSpawnerView: SlotSpawnerViewAbstract
    {
        [SerializeField] private GridLayoutGroup _slotGrid;
        public override SlotView CreateAndReturnSlot()
        {
            GameObject slotGameObject = Instantiate(_slotPrefab, _slotContainerTransform);
            return slotGameObject.GetComponent<SlotView>();
        }

        public override void SetGridColumnSize(int columns)
        {
            _slotGrid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _slotGrid.constraintCount = columns;
        }

        public override void UpdateCanvas()
        {
            Canvas.ForceUpdateCanvases();
        }
    }
}