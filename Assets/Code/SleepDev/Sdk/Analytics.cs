#define LOG_IN_BUILD
using System.Collections.Generic;

namespace SleepDev
{
    public static class Analytics
    {
        public static void OnBuildingBegan(string uid)
        {
#if HAS_SDK
#if UNITY_EDITOR || LOG_IN_BUILD
            CLog.Log($"=== [Analytics] OnBuildingBegan {uid}");
#endif
            MadPixelAnalytics.AnalyticsManager.CustomEvent("building_began", new Dictionary<string, object>()
            {
                {"id", uid}
            });
#endif
        }
        
        public static void OnInstrumentUpgradeBegan(string uid)
        {
#if HAS_SDK
#if UNITY_EDITOR || LOG_IN_BUILD
            CLog.Log($"=== [Analytics] OnInstrumentUpgradeBegan {uid}");
#endif
            MadPixelAnalytics.AnalyticsManager.CustomEvent("instrument_upgrade", new Dictionary<string, object>()
            {
                {"id", uid}
            });
#endif
        }
        
        public static void OnWorkerSummoned(string workerId)
        {
#if HAS_SDK
#if UNITY_EDITOR || LOG_IN_BUILD
            CLog.Log($"=== [Analytics] OnWorkerSummoned {workerId}");
#endif
            MadPixelAnalytics.AnalyticsManager.CustomEvent("worker_summoned", new Dictionary<string, object>()
            {
                {"id", workerId}
            });
#endif
        }
        
        public static void OnWorkerUpgraded(string workerId, int level)
        {
#if HAS_SDK
#if UNITY_EDITOR || LOG_IN_BUILD
            CLog.Log($"=== [Analytics] OnWorkerUpgraded {workerId}, lvl {level}");
#endif
            MadPixelAnalytics.AnalyticsManager.CustomEvent("worker_upgraded", new Dictionary<string, object>()
            {
                {"id", workerId},
                {"level", level}
            });
#endif
        }

    }
}