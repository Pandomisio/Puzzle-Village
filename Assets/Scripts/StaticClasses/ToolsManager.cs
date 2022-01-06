using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ToolsManager// : MonoBehaviour
{
    private static Dictionary<int, int> _tools;
    private static bool _toolsLoaded;


    public static void InitToolsQuantity(Dictionary<int, int> loadedTools)
    {
        // if we lack of smth we have to set it on 0
        if (_toolsLoaded == false)
            _tools = loadedTools;
        _toolsLoaded = true;
    }

    public static List<int> WhatToolBreak(int idOfTool)
    {

        // Loot by puzzleID not resourceID ?
        // Or leave puzzleID only for creating grid and managing him?
        // This could give us diffrent puzzles with same value ( kind of skins )
        if (_toolsLoaded && CheckToolQuantity(idOfTool))
        {
            List<int> list = new List<int>();

            switch (idOfTool)
            {
                case (int)toolType.rake:
                    {
                        list.Add((int)ResourcesAssets.AllResources.grass);
                        return list;
                    }

                case (int)toolType.shovel:
                    {
                        list.Add((int)ResourcesAssets.AllResources.dirt);
                        return list;
                    }
                case (int)toolType.scythe:
                    {
                        list.Add((int)ResourcesAssets.AllResources.wheat);
                        return list;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
        else
            return null;       
    }

    private static bool CheckToolQuantity(int type)
    {
        if (_tools[type] > 0)
            return true;
        else
            return false;
    }
    public static void ToolGatharedResources(int type)
    {
        _tools[type] -= 1;
    }
    public static int GetQuantity (int type )
    {
        if (_tools.ContainsKey(type))
            return _tools[type];
        else
            return -1;
    }

    public enum toolType
    {
        // They have id 0,1,2...
        rake,
        shovel,
        scythe
    }
}
