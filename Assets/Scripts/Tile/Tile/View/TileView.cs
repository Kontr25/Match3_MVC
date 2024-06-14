using UnityEngine;
using UnityEngine.UI;

namespace Tile
{
    public class TileView: TileViewAbstract
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _tileIconImage;
        [SerializeField] private Sprite[] _tileIconSprites;
        public override void Disable()
        {
            _tileIconImage.gameObject.SetActive(false);
        }

        public override void Enable()
        {
            _tileIconImage.gameObject.SetActive(true);
        }

        public override void SetAnchoredPosition(Vector2 targetPosition)
        {
            _rectTransform.anchoredPosition = targetPosition;
        }

        public override void UpdateVisuals(int currentTileID)
        {
            _tileIconImage.sprite = _tileIconSprites[currentTileID];
        }

        public override int MaxTypeID()
        {
            return _tileIconSprites.Length;
        }
    }
}