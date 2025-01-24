using SleepDev.Data;
using TMPro;
using UnityEngine;

namespace SleepDev.UIElements
{
    public class MoneyUI : MonoBehaviour
    {
        public bool subOnEnable;
        public ReactiveInt dataSource;
        
        protected bool _didSub;
        
        public virtual void Init(ReactiveInt source)
        {
            this.dataSource = source;
            OnSet(source.Val, 0);
        }

        public virtual void DoReact(bool react)
        {
            if (react && !_didSub)
            {
                _didSub = true;
                this.dataSource.OnSet += OnSet;
                this.dataSource.OnUpdated += OnUpdated;
                this.dataSource.OnUpdatedWithContext += OnUpdatedContext;
            }
            else if(!react && _didSub)
            {
                _didSub = false;
                this.dataSource.OnSet -= OnSet;
                this.dataSource.OnUpdated -= OnUpdated;
                this.dataSource.OnUpdatedWithContext -= OnUpdatedContext;
            }
        }

        protected virtual void OnSet(int newVal, int prevVal)
        {
            _text.text = newVal.ToString();
        }
        
        protected virtual void OnUpdated(int newVal, int prevVal)
        {
            _text.text = newVal.ToString();
        }
        
        protected virtual void OnUpdatedContext(int newVal, int prev, int context)
        {
            _text.text = newVal.ToString();
        }
        
        [SerializeField] protected TextMeshProUGUI _text;

        protected virtual void OnDisable()
        {
            if (dataSource != null && _didSub)
            {
                _didSub = false;
                this.dataSource.OnSet -= OnSet;
                this.dataSource.OnUpdated -= OnUpdated;
                this.dataSource.OnUpdatedWithContext -= OnUpdatedContext;
            }
        }

        protected virtual void OnEnable()
        {
            if (subOnEnable && dataSource != null && !_didSub)
            {
                DoReact(true);
            }
        }
    }
}