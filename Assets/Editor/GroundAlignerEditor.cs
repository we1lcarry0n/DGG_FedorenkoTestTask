using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GroundAligner))]
public class GroundAlignerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        GroundAligner targetAligner = (GroundAligner)target;
        if (GUILayout.Button("Align to Ground"))
        {
            targetAligner.AlignToGround();  // Create button in Inspector to call the function
        }
    }
}
