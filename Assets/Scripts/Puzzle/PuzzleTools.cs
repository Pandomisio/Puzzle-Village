using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTools : MonoBehaviour
{
    public static PuzzleTools Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public List<int> WhatToolBreak(int idOfTool)
    {
        List<int> list = new List<int>();
        switch (idOfTool)
        {
            case tools.rake:
                {
                    list.Add(PuzzleDictionary.puzzlesTypes.puzzleFarm.grass);
                    list.Add(PuzzleDictionary.puzzlesTypes.puzzleFarm.wheat);
                    return list;
                }

            case 1:
                {
                    return list;
                }
            default:
                {
                    return null;
                }
        }
    }
    public abstract class tools
    {
        public const int rake = 0;
    }
}
