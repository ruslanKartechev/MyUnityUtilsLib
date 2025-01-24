#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace SleepDev
{
    [CustomEditor(typeof(LabelsExample))]
    public class LabelsExampleEditor : Editor
    {
        private LabelsExample me;

        private void OnEnable()
        {
            me = target as LabelsExample;
        }

        public override void OnInspectorGUI()
        {
            EU.Label("Normal Label Left, Not Bold", 'l', false);
            EU.Label("Big Label Left, Not Bold",  EU.font_big,'l', false);
            EU.Label("Large Label Left, Not Bold",  EU.font_large,'l', false);
            EU.Label("Huge Label Left, Not Bold",  EU.font_huge,'l', false);
            EU.Space(EU.space_middle);
            
            EU.Label("Label Center, Bold", 'c', true);
            EU.Label("Label Center, Bold",  EU.font_big, 'c', true);
            EU.Label("Label Center, Bold",  EU.font_large,'c', true);
            EU.Space(EU.space_middle);
            
            EU.Label("Label Center, Bold",  Color.blue, 'c', true);
            EU.Label("Label Center, Bold", Color.cyan,  EU.font_big, 'c', true);
            EU.Label("Label Center, Bold", Color.yellow,  EU.font_large,'c', true);
            EU.Space(EU.space_middle);

            EU.Label("Label Right, Not Bold",  Color.blue, 'r', true);
            EU.Label("Label Right, Not Bold", Color.cyan,  EU.font_big, 'r', true);
            EU.Label("Label Right, Not Bold", Color.yellow,  EU.font_large,'r', true);
        }
    }
}
#endif