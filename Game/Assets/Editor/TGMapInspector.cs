using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(TGMap))]
public class TGMapInspector : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(GUILayout.Button("Reconstruct"))
        {
            TGMap tilemap = (TGMap)target;
            tilemap.ConstructMesh();
        }

        if (GUILayout.Button("Build Walls"))
        {
            TGMap tilemap = (TGMap)target;
            tilemap.ConstructWalls();
        }

        if (GUILayout.Button("Delete Walls"))
        {
            TGMap tilemap = (TGMap)target;
            tilemap.RemoveWallsEditor();
        }
    }
}
