using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(IA_Agent)), CanEditMultipleObjects]
public class IA_AgentEditor : Editor
{
    IA_Agent eTarget = null;
    IA_WorldBuildingManager buildingsManager = null;

    private void OnEnable()
    {
        eTarget = (IA_Agent)target;
        EditorUtility.SetDirty(eTarget);
        if (!buildingsManager)
            buildingsManager = FindObjectOfType<IA_WorldBuildingManager>();
        eTarget.Init();
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        for (int i = 0; buildingsManager&& i < eTarget.AgentSchedule.Count; i++)
        {
            EditorGUILayout.HelpBox($"{eTarget.AgentSchedule[i].StartTime} H - {eTarget.AgentSchedule[i].EndTime} H - {buildingsManager.Get(eTarget.AgentSchedule[i].SelectedBuildingIndex).BuildingType}", MessageType.None);
            eTarget.AgentSchedule[i].StartTime = EditorGUILayout.IntSlider(eTarget.AgentSchedule[i].StartTime, 1,24);
            if (eTarget.AgentSchedule[i].StartTime >= eTarget.AgentSchedule[i].EndTime)
                eTarget.AgentSchedule[i].StartTime = eTarget.AgentSchedule[i].EndTime - 1;
            eTarget.AgentSchedule[i].EndTime = EditorGUILayout.IntSlider(eTarget.AgentSchedule[i].EndTime,1,24);
            if (eTarget.AgentSchedule[i].EndTime <= eTarget.AgentSchedule[i].StartTime)
                eTarget.AgentSchedule[i].EndTime = eTarget.AgentSchedule[i].StartTime + 1;
            if (buildingsManager)
               eTarget.AgentSchedule[i].SelectedBuildingIndex =  EditorGUILayout.Popup(eTarget.AgentSchedule[i].SelectedBuildingIndex, buildingsManager.AllBuildings.Select(b => b.BuildingName).ToArray());
        }
        EditorGUILayout.Space();
        if (GUILayout.Button("Add schedule"))
            eTarget.AddSchedule();
    }
}
