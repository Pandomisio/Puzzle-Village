using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesManager
{

   // public static Dictionary<Sprite,AllResources> allResources = new Dictionary<Sprite, AllResources>();
    private static bool _recourcesLoaded;

    private static Dictionary<int, int> _recources;

    public static void InitResources(Dictionary<int,int> loadedResources)
    {
        // if we lack of smth we have to set it on 0
        if (_recourcesLoaded == false)
            _recources = loadedResources;
        _recourcesLoaded = true;
    }

    public static bool PlayerGatharedResources(Dictionary<int,int> gatheredResources)
    {
        if (_recourcesLoaded)
        {
            foreach (KeyValuePair<int, int> entry in gatheredResources)
            {
                //Debug.Log("Zebra?e?: " + entry.Key + " w ilo?ci: " + entry.Value);
                if (_recources.ContainsKey(entry.Key))
                    _recources[entry.Key] += entry.Value;
                else
                    _recources.Add(entry.Key, entry.Value);
            }
#if UNITY_EDITOR
            PlayerResources_DEBUG();
#endif
            return true;
        }
        else
            return false;

    }

    public static bool PlayerUseRecources(Dictionary<int, int> usedResources)
    {
        if (_recourcesLoaded)
        {
            foreach (KeyValuePair<int, int> entry in usedResources)
            {
                //Debug.Log("Zebra?e?: " + entry.Key + " w ilo?ci: " + entry.Value);
                /*_recources[entry.Key] = _recources[entry.Key] - entry.Value;*/
                _recources[entry.Key] -= entry.Value;
            }
            return true;
        }
        else
            return false;
        
    }

    public static bool PlayerResources_DEBUG()
    {
        if (_recourcesLoaded)
        {
            Debug.Log("Our resources:");
            foreach (KeyValuePair<int, int> entry in _recources)
            {
                Debug.Log("Zebra?e?: " + entry.Key + " w ilo?ci: " + entry.Value);               
            }
            return true;
        }
        else
            return false;

    }
    public static Dictionary<int,int> GetPlayerResorces()
    {
        if (_recourcesLoaded)
            return _recources;
        return null;
    }
    /*
    public enum AllResources
    {
        coins,
        glory,
        crystals,
        grass,
        wheat,
        chicken,
        pig,
        carrot,
        tree,
        dirt,
        iron,
        stone,
        coal,
        gold,
        silver,
        diamond
    };
    */

}
