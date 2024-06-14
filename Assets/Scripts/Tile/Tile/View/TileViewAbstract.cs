using UnityEngine;

namespace Tile
{
    public abstract class TileViewAbstract : MonoBehaviour
    {
        public abstract void Disable(); // Метод, деактивирующий тайл
        public abstract void Enable(); // Метод, активирующий слот
        public abstract void SetAnchoredPosition(Vector2 targetPosition); // Метод, устанавливающий позицию тайла в позицию целевого слота
        public abstract void UpdateVisuals(int currentTileID); // Метод, обновляющий представление слота
                                                               // (замена спрайта, материала или модели слота в зависимости от текущего ID тайла
        public abstract int MaxTypeID(); // Метод, возвращающий максимально возможный индекс тайла (зависит от количества представлений)
    }
}