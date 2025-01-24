#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace SleepDev
{
    [CustomEditor(typeof(TransformEditorComp))]
    public class TransformEditor : Editor
    {
        private TransformEditorComp _comp;

        private void OnEnable()
        {
            _comp = target as TransformEditorComp;
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _comp  = target as TransformEditorComp;
            EU.SpaceMid();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Zero Pos Rot", GUILayout.Width(120)))
            {
                ZeroLocalPosRot();
                UnityEditor.EditorUtility.SetDirty(_comp);
            }
            if (GUILayout.Button("One Scale", GUILayout.Width(120)))
            {
                OneScale();
                UnityEditor.EditorUtility.SetDirty(_comp);
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Look at", GUILayout.Width(120)))
            {
                LookAt();
                UnityEditor.EditorUtility.SetDirty(_comp);
            }
            if (GUILayout.Button("Look opposite", GUILayout.Width(120)))
            {
                LookOpposite();
                UnityEditor.EditorUtility.SetDirty(_comp);
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Copy", GUILayout.Width(120)))
            {
                CopyPosRot();
                UnityEditor.EditorUtility.SetDirty(_comp);
            }
            if (GUILayout.Button("Switch Points", GUILayout.Width(120)))
            {
                SwitchPlaces();
                UnityEditor.EditorUtility.SetDirty(_comp);
            }
            GUILayout.EndHorizontal();
        }
        
        
        public void SwitchPlaces()
        {
            var tr = _comp.transform;
            var src = _comp.copyFrom;
            if (src == null)
            {
                Debug.LogError($"_copyFrom == null");
                return;
            }
            var mPos = tr.position;
            var mRot = tr.rotation;
            var mScale = tr.localScale;
            
            tr.SetPositionAndRotation(src.position, src.rotation);
            tr.localScale = src.localScale;
            
            src.SetPositionAndRotation(mPos, mRot);
            src.localScale = mScale;
         
            UnityEditor.EditorUtility.SetDirty(tr);
            UnityEditor.EditorUtility.SetDirty(src);
        }
        
        public void LookAt()
        {
            if (_comp.lookAt == null)
            {
                Debug.LogError($"_lookAt == null");
                return;
            }
            var tr = _comp.transform;
            tr.rotation = Quaternion.LookRotation(_comp.lookAt.position - tr.position);
            UnityEditor.EditorUtility.SetDirty(this);
        }
        
        public void CopyPosRot()
        {
            if (_comp.copyFrom == null)
            {
                Debug.LogError($"_copyFrom == null");
                return;
            }
            _comp.transform.SetPositionAndRotation(_comp.copyFrom.position, _comp.copyFrom.rotation);
        }
        
        public void ZeroLocalPosRot()
        {
            _comp.transform.localPosition = Vector3.zero;
            _comp.transform.localRotation = Quaternion.identity;
        }

        public void OneScale()
        {
            _comp.transform.localScale = Vector3.one;
        }
        
        public void LookOpposite()
        {
            if (_comp.lookAt == null)
            {
                Debug.LogError($"_lookAt == null");
                return;
            }

            var tr = _comp.transform;
            tr.rotation = Quaternion.LookRotation(-(_comp.lookAt.position - tr.position));
            UnityEditor.EditorUtility.SetDirty(this);
        }
    }
}
#endif