#if HAS_DOTWEEN
using DG.Tweening;
#endif
using UnityEngine;

namespace SleepDev
{
    public class CarouselElementVertical : CarouselElement
    {
        private const float moveTime = .3f;
        private const float moveOffset = 15f;
        
        [SerializeField] private RectTransform _bottom;
        [SerializeField] private RectTransform _pointBottom;
        [SerializeField] private GameObject _pointHighlight;
        
        public override void Close(bool leftToRight)
        {
            Off();
            
        }

        public override void Show(bool leftToRight)
        {
            On();
#if HAS_DOTWEEN
            var anch = _pointBottom.anchoredPosition - Vector2.up * moveOffset;
            _bottom.anchoredPosition = anch;
            _bottom.DOMove(_pointBottom.position, moveTime);
#endif
        }

        public override void On()
        {
            // _top.gameObject.SetActive(true);
            _bottom.gameObject.SetActive(true);
            _pointHighlight.SetActive(true);
        }

        public override void Off()
        {
            // _top.gameObject.SetActive(false);
            _bottom.gameObject.SetActive(false);
            _pointHighlight.SetActive(false);
        }
    }
}