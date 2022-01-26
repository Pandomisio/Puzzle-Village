using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HousesAssets", menuName = "ScriptableObjects/HousesAssets", order = 2)]
public class HousesAssets : ScriptableObject
{
    public static HousesAssets Instance;

    public HousesArray[] _buildings;
   
    // Building
    [Serializable]
    public struct HousesArray
    {
        public BuildingType _enumType;
        // Move sprite to lvl if we get more sprites
        public Sprite _sprite;
        public List<LVLOfBuilding> _levelsOfBuilding;
    }

    // LVLs of buidling
    [Serializable]
    public struct LVLOfBuilding
    {
        public List<RequireResources> _requireResources;
    }

    // Specyfic House and lvl
    [Serializable]
    public struct RequireResources
    {
        public ResourcesAssets.AllResources _requiredResource;
        [Range(0, 100)]
        public int _amountOfResource;
    }

    public enum BuildingType
    {
        none,
        lumberjack,
        farm,
        quarry
    }
}
