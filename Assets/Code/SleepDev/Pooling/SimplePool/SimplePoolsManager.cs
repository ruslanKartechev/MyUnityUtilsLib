﻿using System.Collections.Generic;
using SleepDev;
using UnityEngine;

namespace SleepDev
{
    public class SimplePoolsManager : MonoBehaviour, ISimplePoolsManager
    {
        [SerializeField] private List<Pool> _pools;
        private readonly Dictionary<string, Pool> _poolsMap = new (5);

        public void Init()
        {
            foreach (var pool in _pools)
            {
                _poolsMap.Add(pool.id, pool);
                pool.Init();
            }
            _pools.Clear();            
        }

        public Pool AddPoolIfNot(string id, string prefabPath, int startCount)
        {
            if (_poolsMap.ContainsKey(id))
                return _poolsMap[id];
            var pool = new Pool(id, prefabPath, startCount);
            _poolsMap.Add(id, pool);
            return pool;
        }


        public IPoolItem GetOne(string id)
        {
            if (!_poolsMap.ContainsKey(id))
            {
                CLog.LogError($"_poolsMap doesn't contain pool with id {id}");
                return default;
            }
            var pool = _poolsMap[id];
            return pool.GetOne();
        }

        public void ReturnOne(IPoolItem obj)
        {
            if (!_poolsMap.ContainsKey(obj.PoolId))
            {
                CLog.LogError($"_poolsMap doesn't contain pool with id {obj.PoolId}");
                return;
            }
            _poolsMap[obj.PoolId].Return(obj);
        }

        public bool HasPool(string id)
        {
            return _poolsMap.ContainsKey(id);
        }
    }
}