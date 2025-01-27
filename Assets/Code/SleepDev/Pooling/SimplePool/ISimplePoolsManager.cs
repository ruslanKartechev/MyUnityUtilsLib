﻿namespace SleepDev
{
    public interface ISimplePoolsManager
    {
        IPoolItem GetOne(string type);
        void ReturnOne(IPoolItem obj);
        bool HasPool(string id);
        Pool AddPoolIfNot(string id, string prefabPath, int startCount);
    }
}