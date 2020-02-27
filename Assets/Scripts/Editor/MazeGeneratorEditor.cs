using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MazeGenerator))]
public class MazeGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MazeGenerator generator = (MazeGenerator)target;

        GUILayout.BeginHorizontal();
            if(GUILayout.Button("Generate maze"))
            {
                generator.GenerateMaze();
            }
            if (GUILayout.Button("Reset"))
            {
                generator.Reset();
            }
        GUILayout.EndHorizontal();
    }
}
