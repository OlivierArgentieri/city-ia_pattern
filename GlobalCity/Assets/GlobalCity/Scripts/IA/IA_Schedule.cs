using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class IA_Schedule
{
    [SerializeField, Range(1, 24)] int startTime = 12;
    public int StartTime { get => startTime; set => startTime = value; }
    [SerializeField, Range(1, 24)] int endTime = 13;
    public int EndTime { get => endTime; set => endTime = value; }
    public IA_WorldBuilding SchedulePlace => IA_WorldBuildingManager.Instance?.Get(selectedBuildingIndex);
    [SerializeField] int selectedBuildingIndex = 0;
    public int SelectedBuildingIndex { get => selectedBuildingIndex; set => selectedBuildingIndex = value; }
}
