using System.Collections;
using UnityEngine;

namespace SleepDev
{
    public class SlowMotionManager : MonoBehaviour
    {
     
        public void Begin(SlowMotionConfig config)
        {
            StopTimeChange();
            if (config.EnterTime <= 0)
            {
                _timeScale = config.TimeScale;
                if(config.ScalePhysics)
                    SetTimeAndPhysicsScale();
                else
                    AssignTimeScale(_timeScale);
                return;
            }
            _timeChanging = StartCoroutine(TimeChangingTo(config.TimeScale, config.EnterTime, config.ScalePhysics));
            if(config.Duration > 0)
                StartCoroutine(DelayedReturnToNormal(config));
        }

        public void Exit(SlowMotionConfig config)
        {
            StopTimeChange();
            if (_timeScale == 1f)
                return;
            if (config.ExitTime <= 0)
            {
                _timeScale = 1f;
                if(config.ScalePhysics)
                    SetTimeAndPhysicsScale();
                else
                    AssignTimeScale(_timeScale);
                return;
            }
            _timeChanging = StartCoroutine(TimeChangingTo(1f, config.ExitTime, config.ScalePhysics));
        }

        public void SetNormalTime()
        {
            StopTimeChange();
            _timeScale = 1f;
            SetTimeAndPhysicsScale();
        }


        public static SlowMotionManager Instance { get; private set; }

        private float _timeScale = 1f;
        private float _physycsTimeDelta = 1 / 50f;
        private Coroutine _timeChanging;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
        }
        
        private void AssignTimeScale(float scale) => Time.timeScale = scale;

        private void SetTimeAndPhysicsScale()
        {
            Time.timeScale = _timeScale;
            Time.fixedDeltaTime = _physycsTimeDelta * _timeScale;
        }

        private void StopTimeChange()
        {
            StopAllCoroutines();
            // if( _timeChanging != null)
                // StopCoroutine(_timeChanging);
        }
        
        private IEnumerator DelayedReturnToNormal(SlowMotionConfig config)
        {
            yield return new WaitForSeconds(config.Duration);
            Exit(config);
        }
        
        private IEnumerator TimeChangingTo(float endScale, float time, bool physics)
        {
            var elapsed = 0f;
            var startScale = _timeScale;

            while (elapsed < time)
            {
                _timeScale = Mathf.Lerp(startScale, endScale, elapsed / time);
                if (physics)
                    SetTimeAndPhysicsScale();
                else
                    AssignTimeScale(_timeScale);
                elapsed += Time.unscaledDeltaTime;
                yield return null;
            }
            _timeScale = endScale;
            if (physics)
                SetTimeAndPhysicsScale();
            else
                AssignTimeScale(_timeScale);
        }
    }
}