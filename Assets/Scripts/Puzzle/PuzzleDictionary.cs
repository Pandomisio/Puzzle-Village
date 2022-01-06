using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDictionary : MonoBehaviour
{

    // Not used in project anymore
    // Grid generate in puzzleManager
    // Puzzles and enumtype in PuzzleAssets

    public static PuzzleDictionary Instance;

    public List<GameObject> prefabs;

    private int gameMode;
    private int latestPuzzleType;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetUpGameMode(int type)
    {
        gameMode = type;
    }

    public GameObject GetPuzzle()
    {
        latestPuzzleType = WhatPuzzle();  
        return prefabs[latestPuzzleType];

        // TODO ADD TO THEM AllRESOURCES ENUMTYPE
        /*
         * Jak w scriptable objectie
         * struct z gameobjectem puzzla oraz enumType z AllResources
         */
    }
    public int GetPuzzleType() => latestPuzzleType;

    private int WhatPuzzle()
    {
        int rnd = Random.Range(0, 6);

        if (rnd == 0)
            return (int)puzzleTypes.grass;
        else if (rnd == 1)
            return (int)puzzleTypes.wheat;
        else if (rnd == 2)
            return (int)puzzleTypes.chicken;
        else if (rnd == 3)
            return (int)puzzleTypes.pig;
        else if (rnd == 4)
            return (int)puzzleTypes.carrot;
        else if (rnd == 5)
            return (int)puzzleTypes.tree;
        else
            return (int)puzzleTypes.grass;
    }
    //-- classic
    public enum puzzleTypes
    {
        // farm
        grass,
        wheat,
        chicken, 
        pig,
        carrot,
        tree,
        //-- enemies 
        // farm
        rat,
    /*}
    public enum puzzleMine
    {*/
        // mine
        dirt,
        iron,
        stone,
        coal,
        gold,
        silver,
        diamond,
        // mine
        lava
    }    

}
