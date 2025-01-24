using UnityEngine;

namespace SleepDev
{
    public class SlideElement : MonoBehaviour
    {
        public float inTime;
        public float outTime;
        public Vector2 inPos;
        public Vector2 outPos;
        public RectTransform rect;
        
        public void GoIn()
        {
            if (!gameObject.activeInHierarchy)
                return;
            Stop();
            _working = StartCoroutine(AnimationCoroutines.SlidingRectWithOvershoot(rect, outPos, inPos, inTime));
        }

        public void GoOut()
        {
            if (!gameObject.activeInHierarchy)
                return;
            Stop();
            _working = StartCoroutine(AnimationCoroutines.SlidingRectWithOvershoot(rect, inPos, outPos, outTime));
        }

        public void Stop()
        {
            if(_working != null)
                StopCoroutine(_working);
        }
        
        private Coroutine _working;

      
#if UNITY_EDITOR
        private void OnValidate() => GetRect();

        [ContextMenu("Get Rect")]
        public void GetRect()
        {
            if (rect == null) rect = GetComponent<RectTransform>();
        }

        [ContextMenu("** Save In Pos")]
        public void SaveInPos()
        {
            inPos = rect.anchoredPosition;
            Dirty();
        }
        
        [ContextMenu("Set In Pos")]
        public void SetInPos()
        {
            rect.anchoredPosition = inPos;
            Dirty();
        }
        
        [ContextMenu("** Save Out Pos")]
        public void SaveOutPos()
        {
            outPos = rect.anchoredPosition;
            Dirty();
        }
        
        [ContextMenu("Set Out Pos")]
        public void SetOutPos()
        {
            rect.anchoredPosition = outPos;
            Dirty();
        }

        private void Dirty() => UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}