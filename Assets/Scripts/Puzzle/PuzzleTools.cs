using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PuzzleTools// : MonoBehaviour
{
    /*public static PuzzleTools Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }*/

    public static List<int> WhatToolBreak(int idOfTool)
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
                    return list;
                }
            default:
                {
                    return null;
                }
        }
    }
    /*public abstract class tools
    {
        public const int rake = 0;
    }*/
    public enum toolType
    {
        // They have id 0,1,2...
        rake,
        shovel
    }

    /*public enum toolTypeValue : int
    {
        rake = 0,
        shovel = 1
    }*/
}
