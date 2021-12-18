using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManager : MonoBehaviour
{
    public static puzzleManager Instance;

    [SerializeField] int minPuzzleToGather = 3;
    [SerializeField] float offset = 1.2f;
    // Our prefabs
    // public GameObject[] puzzlePrefabs;

    // Our puzzles
    public GameObject[,] gridOfPuzzles;
    // Every location for puzzle
    private Vector2 [,] positionOfPuzzlesXY;

    private List<Vector2> puzzleSelectedOrder;
    private Vector2 lastSelectedPuzzle;

    // We set it when player start from puzzle
    private bool playerUseFinger;

    // Line on selected puzzles
    private lineController lineController;

    // TO know what player gathered and how much
    List<int> WhatTypesWeCanGather;
    //int playerGatheringPuzzleType;
    int playerGatheringPuzzleCount;

    [SerializeField] private int width, height;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void Start()
    {
        // +1 for creating puzzles above map
        gridOfPuzzles = new GameObject[width, height + 1];
        positionOfPuzzlesXY = new Vector2 [width, height + 1];

        puzzleSelectedOrder = new List<Vector2>();

        // Add singleton
        lineController = transform.GetComponentInChildren<lineController>();



        UI_Manager._instance.SetMoves(2);
        Dictionary<int, int> AmountOfTools = new Dictionary<int,int>();
        //AmountOfTools.Add(PuzzleTools.tools.rake, 3);
        AmountOfTools.Add((int)PuzzleTools.toolType.rake, 3);
        AmountOfTools.Add((int)PuzzleTools.toolType.scythe, 3);
        UI_Manager._instance.SetAmountOfTools(AmountOfTools);

        InitPuzzleGrid();
    }

    private void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetKeyUp(KeyCode.Mouse0))
            FingerUp();
#endif
    }
    private void InitPuzzleGrid()
    {
       for ( int i = 0; i < width; i++ )
       {
            for ( int j = 0; j < height + 1; j++ )
            {
                GameObject newPuzzle = PuzzleDictionary.Instance.GetPuzzle();
                Vector3 childScale = newPuzzle.transform.localScale;
                Vector3 vector3 = PositionForPuzzle(i + (i * childScale.x), j + (j * childScale.y)) ;

                if ( j < height)
                {                   
                    gridOfPuzzles[i, j] = Instantiate(newPuzzle, vector3, transform.rotation);
                    gridOfPuzzles[i, j].transform.parent = transform;
                    gridOfPuzzles[i, j].GetComponent<Puzzle>().SetUpType(PuzzleDictionary.Instance.GetPuzzleType());
                    gridOfPuzzles[i, j].GetComponent<Puzzle>().SetPositionInArray(new Vector2(i, j));
                }
                positionOfPuzzlesXY[i, j] = new Vector2(vector3.x, vector3.y);
            }
       }    
    }

    private Vector3 PositionForPuzzle(float i , float j)
    {
        // .01 to be diffrent then Vector3.zero
        //return new Vector3(transform.position.x + i + .01f, transform.position.y + j + .01f, 0);
        return new Vector3(i + .01f,j + .01f, 0) * offset;
    }

    public void PlayerSelectedPuzzle(Vector2 posInGrid, Vector2 selectedPuzzlePosInArray)
    {
        lineController.NewPuzzleSelected(posInGrid);
        puzzleSelectedOrder.Add(selectedPuzzlePosInArray);
        playerGatheringPuzzleCount++;
    }
    public void TryUnselectPuzzle(Vector2 s)
    {
        if (puzzleSelectedOrder.Count > 1)
        {
            //Debug.Log(puzzleSelectedOrder[puzzleSelectedOrder.Count - 2] + " do " + s);
            if (puzzleSelectedOrder[puzzleSelectedOrder.Count - 2].Equals(s))
            {
                //Debug.Log("TryUnselectPuzzle if true");
                lineController.UnselectLastPuzzle();
                Vector2 pos = puzzleSelectedOrder[puzzleSelectedOrder.Count - 1];
                gridOfPuzzles[(int)pos.x, (int)pos.y].GetComponent<Puzzle>().unSelectPuzzle();
                ActivatePuzzlesAround(s);
                puzzleSelectedOrder.RemoveAt(puzzleSelectedOrder.Count - 1);
                playerGatheringPuzzleCount--;
            }
            /*
            else
                Debug.Log("YOu are the latest puzzle");
            */
        }
    }

    public void FadeTypeOfPuzzle(int type)
    {
        //playerGatheringPuzzleType = type;
        WhatTypesWeCanGather = BonusesManager.WhatTypesWeCanGather(type);
        //WhatTypesWeCanGather = BonusesManager.Instance.WhatTypesWeCanGather(type);
        // We need to get types which we can combine

        foreach ( GameObject puzzle in gridOfPuzzles)
        {
            if (puzzle != null)
            {
                Puzzle puzzleScript = puzzle.GetComponent<Puzzle>();

                if (puzzleScript != null)
                {
                    playerUseFinger = true;
                    puzzleScript.SetPlayerUseFinger();

                    bool activated = false;

                    foreach (int typeAllowed in WhatTypesWeCanGather )
                    {
                        if (puzzleScript.IsSelectedTypePuzzle(typeAllowed))
                        {                            
                            activated = true; 
                            puzzleScript.unFadePuzzle();    
                        }
                        else
                        {
                            if (!activated)
                                puzzleScript.FadePuzzle();
                        }
                    }                   
                }
            }
        }
    }


    // * * *
    // * x *
    // * * *
    // x - pos
    // * - do odblokowania

    public void ActivatePuzzlesAround(Vector2 pos)
    {
        for ( int x = 0; x < 2; x++ )
        {          
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    // x = 0 resetujemy poprzednie pozycje
                    // x = 1 aktywujemy nastepne miejsca

                    int cordX, cordY;
                    if (x == 0)
                    {
                        cordX = (int)lastSelectedPuzzle.x - i;
                        cordY = (int)lastSelectedPuzzle.y - j;          
                    }
                    else
                    {
                        cordX = (int)pos.x - i;
                        cordY = (int)pos.y - j;
                    }
                    

                    if ((cordX > -1 && cordX < width) && (cordY > -1 && cordY < height))
                    {
                        GameObject gameObject = gridOfPuzzles[cordX, cordY];

                        if (gameObject != null)
                        {
                            Puzzle puzzle = gameObject.GetComponent<Puzzle>();

                            if (puzzle != null)
                            {
                                // x = 0 resetujemy poprzednia pozycje
                                // x = 1 aktywujemy nastepne miejsca
                                if (x == 0)
                                {

                                    // Debug.Log("Cant be selected:  " + new Vector2(cordX,cordY));
                                    puzzle.SetCantBeSelected();
                                }
                                else
                                {
                                    foreach (int typeAllowed in WhatTypesWeCanGather)
                                    {
                                        if (puzzle.IsSelectedTypePuzzle(typeAllowed))
                                        {
                                            puzzle.SetCanBeSelected();
                                            // Debug.Log("CAN be selected:  " + new Vector2(cordX, cordY));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }        
        }

        lastSelectedPuzzle = pos;
    }

    private void DestroyPuzzlesInGrid()
    {

        Dictionary<int, int> puzzlesGathered = new Dictionary<int, int>();

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject gameObject = gridOfPuzzles[i, j];
                if (gameObject != null)
                {
                    Puzzle puzzle = gameObject.GetComponent<Puzzle>();
                    if (puzzle != null)
                    {                   
                        if (playerGatheringPuzzleCount > 0)
                        {
                            //if (puzzle.GetIsPuzzleSelected() && puzzle.IsSelectedTypePuzzle(playerGatheringPuzzleType))
                            if (puzzle.GetIsPuzzleSelected())
                            {                              
                                gridOfPuzzles[i, j] = null;
                                playerGatheringPuzzleCount--;

                                if (puzzlesGathered.ContainsKey(puzzle.GetPuzzleType()))
                                    puzzlesGathered[puzzle.GetPuzzleType()] += 1;
                                else
                                    puzzlesGathered.Add(puzzle.GetPuzzleType(), 1);

                                Destroy(puzzle.gameObject);

                            }
                            else
                            {
                                puzzle.SetPlayerDoesntUseFigner();
                                puzzle.SetCantBeSelected();
                            }
                        }
                        else
                        {
                            puzzle.SetPlayerDoesntUseFigner();
                            puzzle.SetCantBeSelected();
                        }
                    }
                }
            }
        }
        //Debug.Log(" Zebra³eœ typ: " + playerGatheringPuzzleType + " w iloœci: " + playerGatheringPuzzleCount);

        SaveOurGatheredPuzzles(puzzlesGathered);

        SortOutGrid();
    }
    private void SaveOurGatheredPuzzles(Dictionary<int,int> gatheredPuzzles)
    {
        foreach (KeyValuePair<int,int> entry in gatheredPuzzles)
        {
            Debug.Log("Zebra³eœ: " + entry.Key + " w iloœci: " + entry.Value);
        }

        // Activate storage with this dictionary to save his gathered Puzzles
    }

    private void SortOutGrid()
    {
        // From bottom to up
        // need to check one above

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject puzzle = gridOfPuzzles[i, j];

                if (puzzle == null)
                {
                    // We need to look higher for falling puzzle
                    GameObject fallingPuzzle;

                    for (int k = j+1; k < height; k++)
                    {
                        if (gridOfPuzzles[i,k] != null)
                        {
                            fallingPuzzle = gridOfPuzzles[i, k];
                            gridOfPuzzles[i, k] = null;
                            gridOfPuzzles[i, j] = fallingPuzzle;

                            gridOfPuzzles[i, j].GetComponent<Puzzle>().GiveNewPosition(positionOfPuzzlesXY[i, j]);
                            gridOfPuzzles[i, j].GetComponent<Puzzle>().SetPositionInArray(new Vector2(i, j));
                            //fallingPuzzle.transform.position = puzzlesPosition[i,j];
                            break;
                        }

                    }

                }
                else
                {
                    // We have an puzzle in this place
                }
            }
        }

        AddNewPuzzlesToGrid();
    }

    private void AddNewPuzzlesToGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (gridOfPuzzles[i, j] == null)
                {

                    GameObject newPuzzle = PuzzleDictionary.Instance.GetPuzzle();
                    Vector3 childScale = newPuzzle.transform.localScale;
                    Vector3 vector3 = PositionForPuzzle(i + (i * childScale.x), j + (j * childScale.y));

                    gridOfPuzzles[i, j] = Instantiate(newPuzzle, positionOfPuzzlesXY[i, height], transform.rotation);

                    gridOfPuzzles[i, j].transform.parent = transform;
                    Puzzle puzzle = gridOfPuzzles[i, j].GetComponent<Puzzle>();
                    puzzle.SetUpType(PuzzleDictionary.Instance.GetPuzzleType());
                    puzzle.GiveNewPosition(vector3);
                    puzzle.SetPositionInArray(new Vector2(i, j));
                }
            }
        }
        //Debug.Log("debugDestroyedPuzzles:" + debugDestroyedPuzzles);
    }
    public void FingerUp()
    {
        if (playerUseFinger == true)
        {
            // Delete actual line
            lineController.ResetLine();
            // Reset collecting order
            puzzleSelectedOrder = new List<Vector2>();

            if (playerGatheringPuzzleCount >= minPuzzleToGather)
            {
                DestroyPuzzlesInGrid();
                UI_Manager._instance.PlayerMoved();
                playerGatheringPuzzleCount = 0;
            }
            else
            {
                foreach (GameObject puzzle in gridOfPuzzles)
                {
                    if (puzzle != null)
                    {

                        Puzzle puzzleScript = puzzle.GetComponent<Puzzle>();
                        if (puzzleScript != null)
                        {
                            puzzleScript.SetPlayerDoesntUseFigner();
                            //puzzleScript.SetCantBeSelected();
                        }

                    }
                }
            }
            playerUseFinger = false;       
            //playerGatheringPuzzleType = -1;          
        }

    }


    //public Dictionary<int,int> UsedTool( int idOfTool )
    public bool UsedTool( int idOfTool )
    {
        int ifWeGetSome = 0;
        // What this tool can do
        //List<int> TypesToGather = PuzzleTools.Instance.WhatToolBreak(idOfTool);
        List<int> TypesToGather = PuzzleTools.WhatToolBreak(idOfTool);

        if (TypesToGather.Count > 0)
        {
            Dictionary<int,int> puzzlesGathered = new Dictionary<int, int>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    GameObject puzzle = gridOfPuzzles[i, j];
                    
                    if (puzzle != null)
                    {
                        Puzzle puzzleComp = puzzle.GetComponent<Puzzle>();
                        
                        if (puzzleComp != null)
                        {
                            foreach (int type in TypesToGather)
                            {
                                if (puzzleComp.IsSelectedTypePuzzle(type))
                                {
                                    // Destroy them and count
                                    Destroy(puzzle.gameObject);
                                    gridOfPuzzles[i, j] = null;
                                    ifWeGetSome++;

                                    if (puzzlesGathered.ContainsKey(type))
                                        puzzlesGathered[type] += 1;
                                    else
                                        puzzlesGathered.Add(type, 1);
                                }
                            }
                        }
                    }
                }
            }
            
            // We destroyed puzzles by tool
            // Time to sort and add new puzzles
            if ( ifWeGetSome > 0 )
            {
                SaveOurGatheredPuzzles(puzzlesGathered);

                SortOutGrid();
                return true;
            }
            else
            {
                // Tool didnt get any puzzle,
                // we can give player it back
                return false;
            }

        }
        return false;
    }
}
