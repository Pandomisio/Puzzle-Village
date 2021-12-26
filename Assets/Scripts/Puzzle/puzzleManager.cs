using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;

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

        //Moves should be there
        UI_Manager._instance.SetMoves(2);

        //Init tools
        Dictionary<int, int> AmountOfTools = new Dictionary<int,int>();
        AmountOfTools.Add((int)ToolsManager.toolType.rake, 3);
        AmountOfTools.Add((int)ToolsManager.toolType.scythe, 3);
        ToolsManager.InitResources(AmountOfTools);
        //Init tool buttons
        UI_Manager._instance.UI_SetAmountInButtons();
        // Init resource Manager
        Dictionary<int, int> resources = new Dictionary<int, int>();
        ResourcesManager.InitResources(resources);

        //InitPuzzleGrid();
    }  

    public void MaxMovesReached()
    {
        SceneManager.LoadScene("MainScene");
    }

    
    public void SaveOurGatheredPuzzles(Dictionary<int,int> gatheredPuzzles)
    {
        /*foreach (KeyValuePair<int,int> entry in gatheredPuzzles)
        {
            Debug.Log("Zebra³eœ: " + entry.Key + " w iloœci: " + entry.Value);
        }*/

        // Activate storage with this dictionary to save his gathered Puzzles
        //Debug.Log("Giving resources to ResourcesManager");
        ClearLog();

        ResourcesManager.PlayerGatharedResources(gatheredPuzzles);
    }

    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
        Debug.Log("ClearLog from puzzleManager");
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
