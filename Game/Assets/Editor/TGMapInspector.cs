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
    }
}
