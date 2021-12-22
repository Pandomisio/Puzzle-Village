using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ToolsManager// : MonoBehaviour
{
    private static Dictionary<int, int> _tools;
    private static bool _toolsLoaded;


    public static void InitResources(Dictionary<int, int> loadedTools)
    {
        // if we lack of smth we have to set it on 0
        _tools = loadedTools;
        _toolsLoaded = true;
    }

    public static List<int> WhatToolBreak(int idOfTool)
    {
        if (_toolsLoaded && CheckToolQuantity(idOfTool))
        {
            List<int> list = new List<int>();

            switch (idOfTool)
            {
                case (int)toolType.rake:
                    {
                        list.Add((int)PuzzleDictionary.puzzleTypes.grass);
                        return list;
                    }

                case (int)toolType.shovel:
                    {
                        list.Add((int)PuzzleDictionary.puzzleTypes.dirt);
                        return list;
                    }
                case (int)toolType.scythe:
                    {
                        list.Add((int)PuzzleDictionary.puzzleTypes.wheat);
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

    /*public abstract class tools
    {
        public const int rake = 0;
    }*/
    public enum toolType
    {
        // They have id 0,1,2...
        rake,
        shovel,
        scythe
    }

    /*public enum toolTypeValue : int
    {
        rake = 0,
        shovel = 1
    }*/
}
