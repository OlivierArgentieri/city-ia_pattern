using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_WorldBuilding : MonoBehaviour
{
    [SerializeField] string buildingName = "Building";
    public string BuildingName => buildingName;
    [SerializeField] IA_WorldBuildingType buildingType = IA_WorldBuildingType.Home;
    public IA_WorldBuildingType BuildingType => buildingType;
    [SerializeField] Color buildingColor = Color.white;
    public Color BuildingColor { get => buildingColor; set => buildingColor = value; }
    public Vector3 Position => transform.position;

    private void Start()
    {
        IA_WorldBuildingManager.Instance.Add(this);
        Outline _outline = gameObject.AddComponent<Outline>();
        _outline.OutlineColor = buildingColor;
        _outline.OutlineWidth = 5;
    }
}

public enum IA_WorldBuildingType
{
    School,
    Restaurant, 
    Home,
    Office
}