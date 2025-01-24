using UnityEngine;
using UnityEngine.UI;

namespace SleepDev.Inventory
{
    public class FadeItemUI : SimpleItemUI
    {
        [SerializeField] private Image _fadeImage;
        public const float FadeTime = .25f;
        
        
        public override void Pick()
        {
            base.Pick();
            gameObject.SetActive(true);
            _fadeImage.gameObject.SetActive(true);
            StartCoroutine(AnimationCoroutines.Fading(_fadeImage, new Vector2(0f, 1f), FadeTime));
        }

        public override void Unpick()
        {
            base.Unpick();
            if(gameObject.activeInHierarchy)
                StartCoroutine(AnimationCoroutines.Fading(_fadeImage, new Vector2(_fadeImage.color.a, 0f), FadeTime));
        }

        public void Blink()
        {
            _fadeImage.gameObject.SetActive(true);
            _fadeImage.enabled = true;
            StartCoroutine(AnimationCoroutines.BlinkImage(_fadeImage, new Vector2(1f, 0f), new Vector2(.22f, .22f), 3));
        }

    }
}