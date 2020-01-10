using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_WorldBuildingManager : MonoBehaviour
{
    public static IA_WorldBuildingManager Instance = null;
    //
    [SerializeField]
    List< IA_WorldBuilding> allBuildings = new List<IA_WorldBuilding>();
    public List<IA_WorldBuilding> AllBuildings => allBuildings;
    public void Awake()
    {
        Instance = this;
    }
    public void Bake()
    {
        IA_WorldBuilding[] _all = FindObjectsOfType<IA_WorldBuilding>();
        for (int i = 0; i < _all.Length; i++)
        {
            Add(_all[i]);
        }
    }

    public IA_WorldBuilding Get(int _buildIndex) => allBuildings[_buildIndex];
    public void Add(IA_WorldBuilding _building)
    {
        if (!allBuildings.Contains(_building))
            allBuildings.Add(_building);
    }

} 
