using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BonusesManager //: MonoBehaviour
{
    //public static BonusesManager Instance;
    private static short allowedMove = 3;

    private static bool buildForester = true;

    public static short GetHowManyMoves() => allowedMove;

    public static void NewBuilding()
    {

    }


    public static List<int> WhatTypesWeCanGather(int type)
    {

        switch (type)
        {
            case (int)ResourcesAssets.AllResources.tree:
                {
                    List<int> typesToMix = new List<int>();
                    if (buildForester)
                    {
                        //Debug.Log("Forester");
                        typesToMix.Add((int)ResourcesAssets.AllResources.tree);
                        typesToMix.Add((int)ResourcesAssets.AllResources.grass);
                        return typesToMix;
                    }
                    else
                    {
                        typesToMix.Add((int)ResourcesAssets.AllResources.tree);
                        return typesToMix;
                    }

                }
            case (int)ResourcesAssets.AllResources.grass:
                {
                    List<int> typesToMix = new List<int>();
                    if (buildForester)
                    {
                        //Debug.Log("Forester");
                        typesToMix.Add((int)ResourcesAssets.AllResources.tree);
                        typesToMix.Add((int)ResourcesAssets.AllResources.grass);
                        return typesToMix;
                    }
                    else
                    {
                        typesToMix.Add((int)ResourcesAssets.AllResources.tree);
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
