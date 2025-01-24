using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
#if HAS_DOTWEEN
using DG.Tweening;
#endif
namespace SleepDev.FlyingUI
{
    public class FlyingElement : MonoBehaviour, IPoolItem
    {
        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        
        public void SetText(string msg) => _text.text = msg;
        
        public void ShowText(bool show) => _text.enabled = show;
        
        public void ShowIcon(bool show) => _icon.enabled = show;

        public void FlyFromTo(Vector3 startPos, Vector3 endScreenPos, float time, Action onEnd = null, float delay = 0f)
        {
            transform.position = startPos;
            gameObject.SetActive(true);
            transform.position = startPos;
#if HAS_DOTWEEN
            transform.DOMove(endScreenPos, time).SetEase(Ease.InCubic).SetDelay(delay).OnComplete(() =>
            {
                Return();
                onEnd?.Invoke();
            });
#endif
        }

        public void FlyFromCenterTo(Vector3 endScreenPos, float time)
        {
            var pos = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
            FlyFromTo(pos, endScreenPos, time);                            
        }
        
        public Pool Pool { get; set; }

        public string PoolId { get; set; }
        
        public GameObject GetGameObject() => gameObject;
        
        public void PoolHide() => gameObject.SetActive(false);

        public void PoolShow() => gameObject.SetActive(true);
        
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _text;

        private void Return()
        {
            PoolHide();
            Pool.Return(this);
        }
        
    }
}