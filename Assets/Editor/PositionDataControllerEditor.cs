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
            targetDataContoller.SavePosition();  // Call Save function from Inspector
        }
        if (GUILayout.Button("Load"))
        {
            targetDataContoller.LoadPosition();  // Call Load function from Inspector
        }
    }
}
