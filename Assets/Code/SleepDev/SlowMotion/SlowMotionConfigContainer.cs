using UnityEngine;

namespace SleepDev
{
    [CreateAssetMenu(menuName = "SO/Slow Motion Config", fileName = "slow motion config", order = -1)]
    public class SlowMotionConfigContainer : ScriptableObject
    {
        public SlowMotionConfig Config => config;

        public void Begin()
        {
            if (SlowMotionManager.Instance == null)
            {
                Debug.LogError($"SlowMotionManager singleton not set. ERROR!");
                return;
            }
            SlowMotionManager.Instance.Begin(Config);
        }

        public void Stop()
        {
            if (SlowMotionManager.Instance == null)
            {
                Debug.LogError($"SlowMotionManager singleton not set. ERROR!");
                return;
            }
            SlowMotionManager.Instance.Exit(Config);
        }
        
        [SerializeField] private SlowMotionConfig config;

    }
}