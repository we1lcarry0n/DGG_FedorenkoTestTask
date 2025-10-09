using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PositionDataController))]
public class PositionDataControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PositionDataController targetDataContoller = (PositionDataController)target;
        if (GUILayout.Button("Save"))
        {
            targetDataContoller.SavePosition();
        }
        if (GUILayout.Button("Load"))
        {
            targetDataContoller.LoadPosition();
        }
    }
}
