using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SleepDev
{
    public class SlideAnimator : MonoBehaviour
    {
        public void SlideIn(Action callback)
        {
            gameObject.SetActive(true);
            StartCoroutine(DelayedCallback(_callbackSlideInTime, callback));
            foreach (var element in _elements)
            {
                element.GoIn();   
            }
        }

        public void SlideOut(Action callback)
        {
            StartCoroutine(DelayedCallback(_callbackSlideOutTime, callback));
            foreach (var element in _elements)
            {
                element.GoOut();   
            }
        }

        private IEnumerator DelayedCallback(float delay, Action callback)
        {
            yield return new WaitForSeconds(delay);
            callback.Invoke();
        }
        [SerializeField] private List<SlideElement> _elements;
        [SerializeField] private float _callbackSlideInTime;
        [SerializeField] private float _callbackSlideOutTime;
        
        
#if UNITY_EDITOR
        [Header("Editor config")]
        public float inTimeForAll;
        public float outTImeForAll;

        [ContextMenu("Get All")]
        public void E_GetAll()
        {
            _elements = MiscUtils.GetFromAllChildren<SlideElement>(transform);
            Dirty();
        }
        
        [ContextMenu("Set In Time All")]
        public void E_SetInTimeAll()
        {
            foreach (var el in _elements)
            {
                if (el == null)
                    continue;
                el.inTime = inTimeForAll;
                Dirty(el);
            }
            Dirty();
        }
        
        [ContextMenu("Set Out Time All")]
        public void E_SetOutTimeAll()
        {
            foreach (var el in _elements)
            {
                if (el == null)
                    continue;
                el.outTime = outTImeForAll;
                Dirty(el);
            }
            Dirty();
        }

        public void E_SaveAllInPos()
        {
            E_ClearNulls();
            foreach (var el in _elements)
                el.SaveInPos();
        }

        public void E_SaveAllOutPos()
        {
            E_ClearNulls();
            foreach (var el in _elements)
                el.SaveOutPos();
        }
        
        [ContextMenu("Clear Nulls")]
        public void E_ClearNulls()
        {
            var count = _elements.Count - 1;
            for (var i = count; i >= 0; i--)
            {
                if(_elements[i] is null)
                    _elements.RemoveAt(i);
            }
            Dirty();
        }

        private void Dirty() => UnityEditor.EditorUtility.SetDirty(this);
        private void Dirty(UnityEngine.Object obj) => UnityEditor.EditorUtility.SetDirty(obj);
#endif
    }
}