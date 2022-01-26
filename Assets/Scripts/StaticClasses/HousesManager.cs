using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HousesManager
{
    // Start is called before the first frame update
    // public static Dictionary<Sprite,AllResources> allResources = new Dictionary<Sprite, AllResources>();
    private static bool _houesesLoaded;
    private static Dictionary<int, int> _buildedHouses;

    public static void InitBuildings(Dictionary<int, int> loadedHouses)
    {
        // if we lack of smth we have to set it on 0
        if (_houesesLoaded == false)
            _buildedHouses = loadedHouses;
        _houesesLoaded = true;
    }

    public static Dictionary<int,int> GetBuildedHouses()
    {
        if ( _houesesLoaded )       
            return _buildedHouses;
        return null;       
    }

    public static Dictionary<int, int> GetHousesToBuild()
    {
        return null; 
    }

    public static void NewHouse(HousesAssets.BuildingType buildingType)
    {
        if (_houesesLoaded)
        {     
            // We have already that house , upgrade?
            int id = (int)buildingType;
            if ( _buildedHouses.ContainsKey(id) )
                _buildedHouses[id] += 1;
            else
                _buildedHouses.Add(id, 1);
            
#if UNITY_EDITOR
            Debug.Log("New house. Its:" + buildingType.ToString());
#endif
        }
    }

    public static int CheckIfWeHaveSpecificHouse(HousesAssets.BuildingType buildingType)
    {
        if (_houesesLoaded)
        {
            int id = (int)buildingType;
            if ( _buildedHouses.ContainsKey(id) )
            {
                return _buildedHouses[id];
            }
            else
                return 0;
        }
        else
            return -1;
    }
}
