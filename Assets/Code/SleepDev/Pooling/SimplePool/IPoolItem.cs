using UnityEngine;

namespace SleepDev
{
    public interface IPoolItem
    {
        GameObject GetGameObject();
        string PoolId { get; set; }
        void PoolHide();
        void PoolShow();
    }
}