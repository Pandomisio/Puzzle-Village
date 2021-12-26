using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BonusesManager //: MonoBehaviour
{
    //public static BonusesManager Instance;

    private static bool buildForester;

    /*
    private static bool buildForester;
    private static bool buildForester;
    private static bool buildForester;
    */

    /*private void Awake()
    {
        if (Instance == null)
            Instance = this;

        buildForester = true;
    }*/



    public static List<int> WhatTypesWeCanGather(int type)
    {

        switch (type)
        {
            case (int)PuzzleDictionary.puzzleTypes.tree:
                {
                    List<int> typesToMix = new List<int>();
                    if (buildForester)
                    {
                        //Debug.Log("Forester");
                        typesToMix.Add((int)PuzzleDictionary.puzzleTypes.tree);
                        typesToMix.Add((int)PuzzleDictionary.puzzleTypes.grass);
                        return typesToMix;
                    }
                    else
                    {
                        typesToMix.Add((int)PuzzleDictionary.puzzleTypes.tree);
                        return typesToMix;
                    }

                }
            default:
                {
                    List<int> typesToMix = new List<int>();
                    typesToMix.Add(type);
                    return typesToMix;
                }
        }
    }


}
