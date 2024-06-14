using UnityEngine;

namespace Slot
{
    public abstract class SlotSpawnerViewAbstract : MonoBehaviour
    {
        [SerializeField] protected GameObject _slotPrefab; // Префаб слота
        [SerializeField] protected Transform _slotContainerTransform; // Родительский объект для слотов, содержащий GridLayoutGroup

        public abstract SlotView CreateAndReturnSlot(); // Метод, создающий и возвращающий вью слота
        public abstract void SetGridColumnSize(int columns); // Метод, устанавливающий количество столбцов игровой сетки. Необходим для изменения данных GridLayoutGroup
        public abstract void UpdateCanvas(); // Метод, принудительно обновляющий все канвасы в игре, чтобы гарантировать корректное отображение изменений
    }
}