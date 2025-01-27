﻿using UnityEngine;

namespace SleepDev
{
    [System.Serializable]
    public class SlowMotionConfig
    {
        public float TimeScale => _timeScale;
        public float Duration => _duration;
        public float EnterTime => _enterTime;
        public float ExitTime => _exitTime;
        public bool ScalePhysics => _scalePhysics;


        public SlowMotionConfig()
        {
            _duration = -1;
            _scalePhysics = false;
            _enterTime = _exitTime = 0f;
            _timeScale = 1f;
        }
        
        public SlowMotionConfig(float timeScale, float duration)
        {
            _timeScale = timeScale;
            _duration = duration;
            _scalePhysics = false;
            _enterTime = _exitTime = 0f;
        }
        
        
        public SlowMotionConfig(float timeScale, float duration, float enterTime)
        {
            _timeScale = timeScale;
            _duration = duration;
            _scalePhysics = false;
            _enterTime = _exitTime = enterTime;
        }
        
        public SlowMotionConfig SetDuration(float duration)
        {
            _duration = duration;
            return this;
        }
        
        public SlowMotionConfig SetEnterTime(float enterTime, bool equalExitTime = true)
        {
            _enterTime = enterTime;
            if (equalExitTime)
                _exitTime = enterTime;
            return this;
        }
        
        public SlowMotionConfig SetExitTime(float enterTime)
        {
            _exitTime = enterTime;
            return this;
        }

        public SlowMotionConfig SetTimeScale(float timeScale)
        {
            _timeScale = timeScale;
            return this;
        }

        public SlowMotionConfig SetPhysics(bool scalePhysTime)
        {
            _scalePhysics = scalePhysTime;
            return this;
        }

        
        [SerializeField] private float _duration;
        [SerializeField] private float _enterTime;
        [SerializeField] private float _exitTime;
        [SerializeField] private float _timeScale;
        [SerializeField] private bool _scalePhysics;
    }
}