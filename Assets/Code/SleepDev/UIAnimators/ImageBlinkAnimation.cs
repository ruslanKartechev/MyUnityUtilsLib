using UnityEngine;

namespace SleepDev
{
    public class ImageBlinkAnimation : MonoBehaviour
    {
        public Vector2 alphaStartEnd;
        public Vector2 time;
        public int blinksCount = 3;
        public UnityEngine.UI.Image image;

        public void Blink()
        {
            image.enabled = true;
            gameObject.SetActive(true);
            if(_blinking!= null)
                StopCoroutine(_blinking);
            _blinking = StartCoroutine(AnimationCoroutines.BlinkImage(image, alphaStartEnd, time, blinksCount));
        }

        private Coroutine _blinking;

    }
}