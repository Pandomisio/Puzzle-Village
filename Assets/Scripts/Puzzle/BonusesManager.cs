using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesManager : MonoBehaviour
{
    public static BonusesManager Instance;

    private bool buildForester;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        buildForester = true;
    }


    public List<int> WhatTypesWeCanGather(int type)
    {

        switch (type)
        {
            case PuzzleDictionary.puzzlesTypes.puzzleFarm.tree:
                {
                    List<int> typesToMix = new List<int>();
                    if (buildForester)
                    {
                        Debug.Log("Forester");
                        typesToMix.Add(PuzzleDictionary.puzzlesTypes.puzzleFarm.tree);
                        typesToMix.Add(PuzzleDictionary.puzzlesTypes.puzzleFarm.grass);
                        return typesToMix;
                    }
                    else
                    {
                        typesToMix.Add(PuzzleDictionary.puzzlesTypes.puzzleFarm.tree);
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
