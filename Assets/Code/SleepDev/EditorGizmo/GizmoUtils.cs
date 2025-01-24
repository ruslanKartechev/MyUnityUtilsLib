using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

namespace SleepDev
{
    public static class GizmoUtils
    {
        public static void DrawBox3D(Vector3 centerPosition, Vector3 size3D, Quaternion rotation)
        {
            var p1 = new Vector3(-size3D.x, -size3D.y, size3D.z) * .5f ;
            var p2 = new Vector3(size3D.x, -size3D.y, size3D.z) * .5f ;
            var p3 = new Vector3(size3D.x, -size3D.y, -size3D.z) * .5f ;
            var p4 = new Vector3(-size3D.x, -size3D.y, -size3D.z) * .5f ;
            p1 = rotation * p1;
            p2 = rotation * p2;
            p3 = rotation * p3;
            p4 = rotation * p4;
            p1 += centerPosition;
            p2 += centerPosition;
            p3 += centerPosition;
            p4 += centerPosition;
            
            Gizmos.DrawLine(p1, p2);
            Gizmos.DrawLine(p2, p3);
            Gizmos.DrawLine(p3, p4);
            Gizmos.DrawLine(p4, p1);
            var upVec = new Vector3(0, size3D.y, 0);
            Gizmos.DrawLine(p1, p1 + upVec);
            Gizmos.DrawLine(p2, p2 + upVec);
            Gizmos.DrawLine(p3, p3 + upVec);
            Gizmos.DrawLine(p4, p4 + upVec);
            
            p1 += upVec;
            p2 += upVec;
            p3 += upVec;
            p4 += upVec;
            Gizmos.DrawLine(p1, p2);
            Gizmos.DrawLine(p2, p3);
            Gizmos.DrawLine(p3, p4);
            Gizmos.DrawLine(p4, p1);

        }
    }
}