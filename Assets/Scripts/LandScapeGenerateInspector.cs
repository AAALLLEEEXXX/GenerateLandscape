using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LandScapeGenerate))]
public class LandScapeGenerateInspector : Editor
{
    LandScapeGenerate myTarget;
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        base.OnInspectorGUI();
        myTarget = (LandScapeGenerate)target;
        if (GUILayout.Button("Generate Landscape"))
        {
            myTarget.GenerateTerrain();
        }
        if (EditorGUI.EndChangeCheck())
        {
            GenerateTerrain();
        }
    }

    private void OnEnable()
    {
        myTarget = (LandScapeGenerate)target;
        Undo.undoRedoPerformed += GenerateTerrain;
    }

    private void OnDisable()
    {
        Undo.undoRedoPerformed -= GenerateTerrain;
    }

    private void GenerateTerrain()
    {
        myTarget.GenerateTerrain();
    }
}
