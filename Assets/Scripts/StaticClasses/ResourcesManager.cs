using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesManager
{
    private static bool _recourcesLoaded;

    private static Dictionary<int, int> _recources;

    public static void InitResources(Dictionary<int,int> loadedResources)
    {
        // if we lack of smth we have to set it on 0
        _recources = loadedResources;
        _recourcesLoaded = true;
    }

    public static bool PlayerGatharedResources(Dictionary<int,int> gatheredResources)
    {
        if (_recourcesLoaded)
        {
            foreach (KeyValuePair<int, int> entry in gatheredResources)
            {
                //Debug.Log("Zebra�e�: " + entry.Key + " w ilo�ci: " + entry.Value);
                _recources[entry.Key] += entry.Value;
            }
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
                //Debug.Log("Zebra�e�: " + entry.Key + " w ilo�ci: " + entry.Value);
                /*_recources[entry.Key] = _recources[entry.Key] - entry.Value;*/
                _recources[entry.Key] -= entry.Value;
            }
            return true;
        }
        else
            return false;
        
    }
    
}
