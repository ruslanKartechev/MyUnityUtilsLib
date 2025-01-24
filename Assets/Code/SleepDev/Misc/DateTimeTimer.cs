using System;
using System.Collections;
using UnityEngine;

namespace SleepDev
{
    public class DateTimeTimer : MonoBehaviour
    {
        public DateTimeData EndTime { get; set; }

        public event Action OnTimerEnd;
        
        /// <summary>
        /// </summary>
        /// <param name="endTime">Time when the timer ends</param>
        /// <returns>True if timer will begin. False if time already passed</returns>
        public bool BeginTiming(DateTimeData endTime)
        {
            StopTiming();
            if (IsDone(endTime))
            {
                CLog.Log($"[{nameof(DateTimeTimer)}] End time already passed");
                return false;
            }
            EndTime = endTime;
            if (_useTimerView)
            {
                if (_timerView == null)
                    _timerView = gameObject.GetComponent<IDateTimeTimerView>();
                _working = StartCoroutine(TimingWithView());
            }
            else
            {
                _working = StartCoroutine(Timing());
            }
            return true;
        }

        public bool IsDone(DateTimeData endTime)
        {
            var temp = endTime.GetDateTime() - DateTime.Now;
            return temp.TotalSeconds < 1;
        }

        public void ClearEventListeners()
        {
            OnTimerEnd = null;
        }

        public void StopTiming()
        {
            if(_working != null)
                StopCoroutine(_working);
        }

        public IDateTimeTimerView TimerView
        {
            get => _timerView;
            set => _timerView = value;
        }

        public bool UseTimerView
        {
            get => _useTimerView;
            set => _useTimerView = value;
        }
        
        [SerializeField] private bool _useTimerView = true;
        private Coroutine _working;
        private IDateTimeTimerView _timerView;
        
        private IEnumerator Timing()
        {
            var isDone = false;
            var endDt = EndTime.GetDateTime();
            while (!isDone)
            {
                yield return null;
                var temp = endDt - DateTime.Now;
                isDone = temp.TotalSeconds < 1;
            }
            OnTimerEnd?.Invoke();
        }
        
        private IEnumerator TimingWithView()
        {
            var isDone = false;
            var endDt = EndTime.GetDateTime();
            while (!isDone)
            {
                yield return null;
                var temp = endDt - DateTime.Now;
                isDone = temp.TotalSeconds < 1;
                _timerView.SetTime(temp);
            }
            OnTimerEnd?.Invoke();
        }
    }
}