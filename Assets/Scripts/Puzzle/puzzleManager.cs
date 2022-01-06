using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;

public class puzzleManager : MonoBehaviour
{
    public static puzzleManager _instance;

    private puzzleGrid puzzleGrid;

    [SerializeField] int minPuzzleToGather = 3;
    [SerializeField] float offset = 1.2f;
    [SerializeField] short roundLIMIT;

    [SerializeField] PuzzlesAssets puzzlesAssets;

    // Our prefabs
    // public GameObject[] puzzlePrefabs;

    // Our puzzles
    public GameObject[,] gridOfPuzzles;
    // Every location for puzzle

    [SerializeField] private int width, height;

    public void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public void Start()
    {
        puzzleGrid = GetComponent<puzzleGrid>();
        puzzleGrid.InitPuzzleGrid(width, height , offset, minPuzzleToGather);

        //Moves should be there
        UI_Manager._instance.SetMoves(BonusesManager.GetHowManyMoves());

        //This parts should be loaded with start of a game
        //Init tools
        Dictionary<int, int> AmountOfTools = new Dictionary<int,int>();
        AmountOfTools.Add((int)ToolsManager.toolType.rake, 3);
        AmountOfTools.Add((int)ToolsManager.toolType.scythe, 3);
        ToolsManager.InitToolsQuantity(AmountOfTools);
        //Init tool buttons
        UI_Manager._instance.UI_SetAmountInButtons();
        // Init resource Manager
        Dictionary<int, int> resources = new Dictionary<int, int>();
        ResourcesManager.InitResources(resources);

        //InitPuzzleGrid();
    }  

    public GameObject GetPuzzle()
    {
        int lotery = NewPuzzle();
        GameObject newPuzzle = null;
        Debug.Log(lotery);
        foreach (var puzzle in puzzlesAssets._puzzles)
        {
            Debug.Log((int)puzzle._type);
            if (lotery == (int)puzzle._type)
            {
                newPuzzle = puzzle._prefab;
                break;
            }
        }
        Debug.Log(newPuzzle);
        return newPuzzle;
    }

    private int NewPuzzle()
    {
        int rnd = Random.Range(0, 6);

        if (rnd == 0)
            return (int)PuzzlesAssets.puzzleTypes.grass;
        else if (rnd == 1)
            return (int)PuzzlesAssets.puzzleTypes.wheat;
        else if (rnd == 2)
            return (int)PuzzlesAssets.puzzleTypes.chicken;
        else if (rnd == 3)
            return (int)PuzzlesAssets.puzzleTypes.pig;
        else if (rnd == 4)
            return (int)PuzzlesAssets.puzzleTypes.carrot;
        else if (rnd == 5)
            return (int)PuzzlesAssets.puzzleTypes.tree;
        else
            return (int)PuzzlesAssets.puzzleTypes.grass;
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
#if UNITY_EDITOR
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
        Debug.Log("ClearLog from puzzleManager");
#endif
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
