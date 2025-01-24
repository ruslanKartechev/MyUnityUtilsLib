#if HAS_DOTWEEN
using DG.Tweening;
#endif
using UnityEngine;

namespace SleepDev.Inventory
{
    public class ScaleItemUI : SimpleItemUI
    {
        public const float ScaleTime = .25f;
        
        [SerializeField] protected float _scaleUp = 1.1f;
        [SerializeField] protected RectTransform _target;
        [SerializeField] protected GameObject _darkening;
        #if HAS_DOTWEEN
        protected Tween _scaling;
        #endif
        public override void Pick()
        {
            base.Pick();
            _target.gameObject.SetActive(true);
#if HAS_DOTWEEN
            _scaling?.Kill();
            _target.localScale = Vector3.one;
            _scaling = _target.DOScale(_scaleUp, ScaleTime);
#endif
            _darkening.SetActive(false);
        }

        public override void Unpick()
        {
            base.Unpick();
#if HAS_DOTWEEN
            _scaling?.Kill();
            _scaling = _target.DOScale(Vector3.one, ScaleTime);
#endif
            _darkening.SetActive(true);
        }
    }
}