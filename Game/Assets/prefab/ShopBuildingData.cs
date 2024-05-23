using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building/BuildingData", fileName = "BuildingData")]
public class ShopBuildingData : ScriptableObject 
{
    public string Name;
    public int Cost;
    public float TimeConstruction;
    public GameObject PrefabBuilding;
}
