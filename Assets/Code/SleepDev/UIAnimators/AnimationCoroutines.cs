using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SleepDev
{
    public static class AnimationCoroutines
    {
        
        public static IEnumerator BlinkImage(Image image, Vector2 alphaMinMax, Vector2 timeToBack, int blinksCount)
        {
            var elapsed = 0f;
            var time = timeToBack.x;
            var v = 0.9f;
            var a = 1.2f;
            for (var blinkInd = 0; blinkInd < blinksCount; blinkInd++)
            {
                var color = image.color;
                while (elapsed <= time)
                {
                    color.a = Mathf.Lerp(alphaMinMax.x, alphaMinMax.y, elapsed / time);
                    image.color = color;
                    elapsed += Time.deltaTime * v;
                    v += a * Time.deltaTime;
                    yield return null;
                }
                color.a = alphaMinMax.y;
                image.color = color;
                yield return null;
                elapsed = 0f;
                time = timeToBack.y;
                while (elapsed <= time)
                {
                    color.a = Mathf.Lerp(alphaMinMax.y, alphaMinMax.x, elapsed / time);
                    image.color = color;
                    elapsed += Time.deltaTime * v;
                    v += a * Time.deltaTime;
                    yield return null;
                }
                color.a = alphaMinMax.x;
                image.color = color;
            }
        }


        public static IEnumerator Fading(Image image, Vector2 alphaFromTo, float time)
        {
            var elapsed = 0f;
            var color = image.color;
            while (elapsed <= time)
            {
                color.a = Mathf.Lerp(alphaFromTo.x, alphaFromTo.y, elapsed /time);
                image.color = color;
                elapsed += Time.deltaTime;
                yield return null;
            }
            color.a = alphaFromTo.y;
            image.color = color;
        }

        public static IEnumerator SlidingRectWithOvershoot(RectTransform rect, Vector2 from, Vector2 to, float timeTotal, float overShoot = 16f)
        {
            var elapsed = Time.deltaTime;
            var time = timeTotal * .78f;
            var t = elapsed / time;
            var maxT = 1 + overShoot / 100f;
            while (t < 1f)
            {
                var lerpT = Mathf.Lerp(0f, maxT, t);
                var p = Vector2.LerpUnclamped(from, to, lerpT);
                rect.anchoredPosition = p;
                elapsed += Time.deltaTime;
                t = elapsed / time;
                yield return null;
            }
            elapsed = 0f;
            time = timeTotal * .22f;
            t = elapsed / time;
            while (t < 1f)
            {
                var lerpT = Mathf.Lerp(maxT, 1f, t);
                var p = Vector2.LerpUnclamped(from, to, lerpT);
                rect.anchoredPosition = p;
                elapsed += Time.deltaTime;
                t = elapsed / time;
                yield return null;
            }
            rect.anchoredPosition = to;
        }
    }
}