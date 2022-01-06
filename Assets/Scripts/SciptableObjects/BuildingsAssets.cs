using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingAssets", menuName = "ScriptableObjects/BuildingAssets", order = 2)]
public class BuildingsAssets : ScriptableObject
{
    public BuildingArray[] _buildings;
   
    [Serializable]
    public struct BuildingArray
    {
        public BuildingType _enumType;
        public Sprite _sprite;
    }

    public enum BuildingType
    {
        lumberjack
    }
}
