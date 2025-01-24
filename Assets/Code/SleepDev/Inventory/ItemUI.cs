using UnityEngine;

namespace SleepDev.Inventory
{
    public abstract class ItemUI : MonoBehaviour
    {
        public virtual object ObjectInside { get; set; }
        
        public virtual string Id { get; set; }
        public virtual int NumberId { get; set; }
        
        public virtual bool IsPicked { get; protected set; }
        
        public virtual bool IsAllowedToPick { get; set; } = true;
        
        public abstract void Pick();
        public abstract void Unpick();
        public abstract void SetCount(int count);
        public abstract int GetCount();
        
    }
}