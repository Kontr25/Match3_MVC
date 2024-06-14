using UnityEngine;
using UnityEngine.UI;

namespace Tile
{
    public class TileSpawnerView: TileSpawnerViewAbstract
    {
        [SerializeField] protected GameObject _tilePrefab;
        [SerializeField] protected Transform _container;
        [SerializeField] private GridLayoutGroup _slotGrid;

        public override TileViewAbstract CreateAndReturnTileView()
        {
            GameObject tileObject = Instantiate(_tilePrefab, _container);
            RectTransform rectTransform = tileObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(_slotGrid.cellSize.x, _slotGrid.cellSize.y);
            
            return tileObject.GetComponent<TileViewAbstract>();
        }
    }
}