using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDictionary : MonoBehaviour
{
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
    }
    public int GetPuzzleType() => latestPuzzleType;

    private int WhatPuzzle()
    {
        int rnd = Random.Range(0, 6);

        if (rnd == 0)
            return puzzlesTypes.puzzleFarm.grass;
        else if (rnd == 1)
            return puzzlesTypes.puzzleFarm.wheat;
        else if (rnd == 2)
            return puzzlesTypes.puzzleFarm.chicken;
        else if (rnd == 3)
            return puzzlesTypes.puzzleFarm.pig;
        else if (rnd == 4)
            return puzzlesTypes.puzzleFarm.carrot;
        else if (rnd == 5)
            return puzzlesTypes.puzzleFarm.tree;
        else
            return puzzlesTypes.puzzleFarm.grass;
    }

    public abstract class puzzlesGamesTypes
    {
        //-- classic
        public const int farm = 1;
        public const int mine = 2;
    }

    public abstract class puzzlesTypes
    {
        //-- classic
        public abstract class puzzleFarm
        {
            // farm
            public const int grass = 0;
            public const int wheat = 1;
            public const int chicken = 2;
            public const int pig = 3;
            public const int carrot = 4;
            public const int tree = 5;

            //-- enemies 
            // farm
            const int rat = 40;
        }
        public abstract class puzzleMine
        {
            // mine
            public const int dirt = 50;
            public const int iron = 51;
            public const int stone = 52;
            public const int coal = 53;
            public const int gold = 54;
            public const int silver = 55;
            public const int diamond = 56;

            // mine
            const int lava = 80;
        }

    }

}
