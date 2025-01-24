using UnityEngine;

namespace SleepDev
{
    public class TransformEditorComp : MonoBehaviour
    {
#if UNITY_EDITOR
        public Transform copyFrom;
        public Transform lookAt;
#endif
    }
}