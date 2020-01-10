using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IA_WorldBuildingManager))]
public class IA_WorldBuildingManagerEditor : Editor
{
    IA_WorldBuildingManager eTarget = null;
    private void OnEnable()
    {
        eTarget = (IA_WorldBuildingManager)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Bake buildings"))
        {
            eTarget.Bake();
        }
        EditorGUILayout.Space();
        for (int i = 0; i < eTarget.AllBuildings.Count; i++)
        {
            GUILayout.Label($"{eTarget.AllBuildings[i].BuildingName} - {eTarget.AllBuildings[i].BuildingType}");
            EditorGUILayout.BeginHorizontal();
            eTarget.AllBuildings[i].BuildingColor = EditorGUILayout.ColorField(eTarget.AllBuildings[i].BuildingColor);
            if (GUILayout.Button("select"))
                Selection.activeObject = eTarget.AllBuildings[i];
            EditorGUILayout.EndHorizontal();
        }
    }
}
