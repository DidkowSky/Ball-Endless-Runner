using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace Tools
{
    [CustomEditor(typeof(LevelSegments))]
    public class LevelSegmentEditor : Editor
    {
        private ReorderableList segmentsList;

        private void OnEnable()
        {
            segmentsList = new ReorderableList(serializedObject, serializedObject.FindProperty("Segments"), true, true, true, true);
            segmentsList.drawHeaderCallback += OnDrawSegmentHeader;
            segmentsList.drawElementCallback += OnDrawSegment;
        }

        private void OnDisable()
        {
            segmentsList.drawHeaderCallback -= OnDrawSegmentHeader;
            segmentsList.drawElementCallback -= OnDrawSegment;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            segmentsList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        private void OnDrawSegmentHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "");

            if (GUI.Button(new Rect(rect.x + 14, rect.y, rect.width - 150, EditorGUIUtility.singleLineHeight), "GameObject", EditorStyles.label))
            {

            }

            if (GUI.Button(new Rect(rect.x + rect.width - 120, rect.y, 120, EditorGUIUtility.singleLineHeight), "Forward Extension", EditorStyles.label))
            {

            }
        }

        private void OnDrawSegment(Rect rect, int index, bool isActive, bool isFocused)
        {
            var element = segmentsList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width - 150, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("SegmentObject"), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + rect.width - 100, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("ForwardExtension"), GUIContent.none);
        }
    }
}
