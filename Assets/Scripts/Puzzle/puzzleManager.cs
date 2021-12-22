using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManager : MonoBehaviour
{
    public static puzzleManager Instance;

    private puzzleGrid puzzleGrid;

    [SerializeField] int minPuzzleToGather = 3;
    [SerializeField] float offset = 1.2f;
    // Our prefabs
    // public GameObject[] puzzlePrefabs;

    // Our puzzles
    public GameObject[,] gridOfPuzzles;
    // Every location for puzzle

    [SerializeField] private int width, height;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void Start()
    {
        puzzleGrid = GetComponent<puzzleGrid>();
        puzzleGrid.InitPuzzleGrid(width, height , offset, minPuzzleToGather);

        UI_Manager._instance.SetMoves(2);
        Dictionary<int, int> AmountOfTools = new Dictionary<int,int>();
        //AmountOfTools.Add(PuzzleTools.tools.rake, 3);
        AmountOfTools.Add((int)ToolsManager.toolType.rake, 3);
        AmountOfTools.Add((int)ToolsManager.toolType.scythe, 3);
        //UI_Manager._instance.SetAmountOfTools(AmountOfTools);
        ToolsManager.InitResources(AmountOfTools);
        UI_Manager._instance.UI_SetAmountInButtons();



        //InitPuzzleGrid();
    }  

    
    public void SaveOurGatheredPuzzles(Dictionary<int,int> gatheredPuzzles)
    {
        foreach (KeyValuePair<int,int> entry in gatheredPuzzles)
        {
            Debug.Log("Zebra³eœ: " + entry.Key + " w iloœci: " + entry.Value);
        }

        // Activate storage with this dictionary to save his gathered Puzzles
    }  

    public void FingerUp()
    {
        puzzleGrid.FingerUp();
    }


    //public Dictionary<int,int> UsedTool( int idOfTool )
    public bool UsedTool( int idOfTool )
    {
        // What this tool can do
        //List<int> TypesToGather = PuzzleTools.Instance.WhatToolBreak(idOfTool);
        List<int> TypesToGather = ToolsManager.WhatToolBreak(idOfTool);
        if (TypesToGather == null)
            return false;
        if (TypesToGather.Count > 0)
        {          
            return (puzzleGrid.UsedTool(TypesToGather));
        }
        else
            return false;
    }
}
