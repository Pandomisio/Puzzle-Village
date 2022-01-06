using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PuzzlesAssets", menuName = "ScriptableObjects/PuzzlesAssets", order = 1)]

public class PuzzlesAssets : ScriptableObject
{
    public Puzzle[] _puzzles;

    [Serializable]
    public struct Puzzle
    {
        public puzzleTypes _type;
        public GameObject _prefab;
        //public 
    }

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
