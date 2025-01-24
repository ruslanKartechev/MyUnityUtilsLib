using System.Collections;
using UnityEngine;
#if HAS_DOTWEEN
using DG.Tweening;
#endif

namespace SleepDev
{
    public class TouchScreenHand : MonoBehaviour 
    {
        [SerializeField] private float _scaleNormal = 1f;
        [SerializeField] private float _scaleDown = .9f;
        [SerializeField] private float _scaleTime = .2f;
        [SerializeField] private float _hideDelay = .2f;
        [SerializeField] private Transform _hand;
        private bool _isDown;
        private Coroutine _scaling;

        private void Awake()
        {
            _hand.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDown = true;
                _hand.position = Input.mousePosition;
                StopScaling();
#if HAS_DOTWEEN
                _hand.DOKill();
                _hand.localScale = Vector3.one * _scaleNormal;
                _hand.gameObject.SetActive(true);
                _hand.DOScale(Vector3.one * _scaleDown, _scaleTime);
#endif
            }
            else if (_isDown && Input.GetMouseButtonUp(0))
            {
                _isDown = false;
                StopScaling();
                _scaling = StartCoroutine(DelayedHide());
            }
            else if (_isDown)
            {
                _hand.position = Input.mousePosition;
            }
        }

        private void StopScaling()
        {
            if(_scaling != null)
                StopCoroutine(_scaling);
        }
        
        private IEnumerator DelayedHide()
        {
#if HAS_DOTWEEN
            _hand.DOKill();
            _hand.DOScale(Vector3.one * _scaleNormal, _scaleTime);
            yield return new WaitForSeconds(_hideDelay);
            _hand.gameObject.SetActive(false);
#else
            yield return null;
            _hand.gameObject.SetActive(false);
#endif
        }
    }
}