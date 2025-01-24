#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace SleepDev
{
    [CustomEditor(typeof(SlideAnimator))]
    public class SlideAnimatorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EU.Label("Slide Animator", EU.RoyalBlue, fontSize: 26);
            EU.Space();
            base.OnInspectorGUI();
            var me = target as SlideAnimator;
            EU.SpaceMid();
            GUILayout.BeginHorizontal();
            if (EU.BtnMidWide("Grab Refs", EU.RoyalBlue))
                me.E_GetAll();
            if (EU.BtnMidWide("Clear Nulls", EU.RoyalBlue))
                me.E_ClearNulls();
            GUILayout.EndHorizontal();
            EU.Space();
            
            GUILayout.BeginHorizontal();
            if (EU.BtnMidWide2("Save All In Pos", EU.Orange))
                me.E_SaveAllInPos();
            if (EU.BtnMidWide2("Save All Out Pos", EU.Orange))
                me.E_SaveAllOutPos();
            GUILayout.EndHorizontal();
            EU.Space();

            GUILayout.BeginHorizontal();
            if (EU.BtnMidWide2("Set All Time In", EU.DeepPink))
                me.E_SetInTimeAll();
            if (EU.BtnMidWide2("Set All Time Out", EU.DeepPink))
                me.E_SetOutTimeAll();
            GUILayout.EndHorizontal();
            
        }
    }
}
#endif