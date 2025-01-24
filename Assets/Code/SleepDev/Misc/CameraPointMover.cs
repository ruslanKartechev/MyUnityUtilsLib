using UnityEngine;

namespace SleepDev
{
    public class CameraPointMover : MonoBehaviour
    {
        private static CameraPointMover _instance;

        public static void SetToPoint(ICameraPoint point)
        {
            var movable = Camera.main.transform;
            var i = 0;
            const int iMax = 100;
            while (movable.parent != null && i < iMax)
            {
                i++;
                if (movable.TryGetComponent<CameraPointMover>(out var m))
                    break;
                if (movable.TryGetComponent<CameraShaker>(out var s))
                    break;
                movable = movable.parent;
            }
            // Debug.Log($"Movable name {movable.name}");
            movable.CopyPosRot(point.GetPoint());
        }
        
        public static void ParentToPoint(ICameraPoint point, bool center = true) => _instance.CamParentToPoint(point, center);
        
        
        [SerializeField] private Transform _movable;

        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            _instance = this;
        }
        #endif

        private void OnEnable()
        {
            _instance = this;
        }

        private void CamSetToPoint(ICameraPoint point)
        {
            var pp = point.GetPoint();
            _movable.SetPositionAndRotation(pp.position, pp.rotation);
        }

        private void CamParentToPoint(ICameraPoint point, bool center = true)
        {
            var pp = point.GetPoint();
            _movable.parent = pp;
            if(center)
                _movable.SetPositionAndRotation(pp.position, pp.rotation);
        }
    }
}