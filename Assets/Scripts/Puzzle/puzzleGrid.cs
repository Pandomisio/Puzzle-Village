using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleGrid : MonoBehaviour
{
    [SerializeField] int minPuzzleToGather = 3;
    [SerializeField] float offset = 1.2f;
    // Our prefabs
    // public GameObject[] puzzlePrefabs;

    // Our puzzles
    public GameObject[,] puzzles;
    // Every location for puzzle
    private Vector2 [,] puzzlesPosition;

    private List<Vector2> puzzleSelectedOrder;
    private Vector2 lastSelectedPuzzle;

    // We set it when player start from puzzle
    private bool playerUseFinger;

    public lineController lineController;

    // TO know what player gathered and how much
    int playerGatheringPuzzleType;
    int playerGatheringPuzzleCount;

    [SerializeField] private int width, height;
    public void Start()
    {
        // +1 for creating puzzles above map
        puzzles = new GameObject[width, height + 1];
        puzzlesPosition = new Vector2 [width, height + 1];

        puzzleSelectedOrder = new List<Vector2>();

        // Add singleton
        lineController = transform.GetComponentInChildren<lineController>();

        InitPuzzleGrid();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
            FingerUp();

    }
    private void InitPuzzleGrid()
    {
       for ( int i = 0; i < width; i++ )
       {
            for ( int j = 0; j < height + 1; j++ )
            {
                /*int getPuzzleType = WhatPuzzleToGrid();
                Vector3 childScale = puzzlePrefabs[getPuzzleType].transform.localScale;
                Vector3 vector3 = PositionForPuzzle(i + (i * childScale.x), j + (j * childScale.y));*/

                GameObject newPuzzle = PuzzleDictionary.Instance.GetPuzzle();
                Vector3 childScale = newPuzzle.transform.localScale;
                Vector3 vector3 = PositionForPuzzle(i + (i * childScale.x), j + (j * childScale.y)) ;

                if ( j < height)
                {
                    // Init a prefab and make him a child
                    /*puzzles[i, j] = Instantiate(puzzlePrefabs[getPuzzleType], vector3, transform.rotation);
                    puzzles[i, j].transform.parent = transform;
                    puzzles[i, j].GetComponent<Puzzle>().SetUpType(getPuzzleType);
                    puzzles[i, j].GetComponent<Puzzle>().SetPositionInArray(new Vector2(i, j));*/

                    
                    puzzles[i, j] = Instantiate(newPuzzle, vector3, transform.rotation);
                    puzzles[i, j].transform.parent = transform;
                    puzzles[i, j].GetComponent<Puzzle>().SetUpType(PuzzleDictionary.Instance.GetPuzzleType());
                    puzzles[i, j].GetComponent<Puzzle>().SetPositionInArray(new Vector2(i, j));

                }

                puzzlesPosition[i, j] = new Vector2(vector3.x, vector3.y);
            }
       }    
    }
    private int WhatPuzzleToGrid()
    {
        int rnd = Random.Range(0, 2);
        if (rnd == 0)
            return puzzlesTypes.puzzleFarm.grass;
        else
            return puzzlesTypes.puzzleFarm.wheat;
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
                puzzles[(int)pos.x, (int)pos.y].GetComponent<Puzzle>().unSelectPuzzle();
                ActivatePuzzlesAround(s);
                puzzleSelectedOrder.RemoveAt(puzzleSelectedOrder.Count - 1);
            }
            /*
            else
                Debug.Log("YOu are the latest puzzle");
            */
        }
    }

    public void FadeTypeOfPuzzle(int type)
    {
        playerGatheringPuzzleType = type;
        foreach ( GameObject puzzle in puzzles)
        {
            if (puzzle != null)
            {
                Puzzle puzzleScript = puzzle.GetComponent<Puzzle>();

                if (puzzleScript != null)
                {
                    playerUseFinger = true;
                    puzzleScript.SetPlayerUseFinger();

                    if (!puzzleScript.IsSelectedTypePuzzle(type))
                    {
                        puzzleScript.FadePuzzle();
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
                        GameObject gameObject = puzzles[cordX, cordY];

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
                                    if (puzzle.IsSelectedTypePuzzle(playerGatheringPuzzleType))
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

        lastSelectedPuzzle = pos;
    }

    private void DestroyPuzzlesInGrid()
    {
        playerGatheringPuzzleCount = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject gameObject = puzzles[i, j];
                if (gameObject != null)
                {
                    Puzzle puzzle = gameObject.GetComponent<Puzzle>();
                    if (puzzle.GetIsPuzzleSelected() && puzzle.IsSelectedTypePuzzle(playerGatheringPuzzleType))
                    {
                        Destroy(puzzle.gameObject);
                        puzzles[i, j] = null;
                        playerGatheringPuzzleCount++;
                    }
                    else
                        puzzle.SetCantBeSelected();
                }
            }
        }
        Debug.Log(" Zebra�e� typ: " + playerGatheringPuzzleType + " w ilo�ci: " + playerGatheringPuzzleCount);

        SortOutGrid();
    }

    private void SortOutGrid()
    {
        // From bottom to up
        // need to check one above

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject puzzle = puzzles[i, j];

                if (puzzle == null)
                {
                    // We need to look higher for falling puzzle
                    GameObject fallingPuzzle;

                    for (int k = j+1; k < height; k++)
                    {
                        if (puzzles[i,k] != null)
                        {
                            fallingPuzzle = puzzles[i, k];
                            puzzles[i, k] = null;
                            puzzles[i, j] = fallingPuzzle;

                            puzzles[i, j].GetComponent<Puzzle>().GiveNewPosition(puzzlesPosition[i, j]);
                            puzzles[i, j].GetComponent<Puzzle>().SetPositionInArray(new Vector2(i, j));
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
        int debugDestroyedPuzzles = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (puzzles[i, j] == null)
                {
                    debugDestroyedPuzzles++;

                    /*int getPuzzleType = WhatPuzzleToGrid();
                    Vector3 vector3 = new Vector3(puzzlesPosition[i, j].x, puzzlesPosition[i, j].y, 0f);
                    
                    // Init a prefab and make him a child
                    puzzles[i, j] = Instantiate(puzzlePrefabs[getPuzzleType], puzzlesPosition[i, height], transform.rotation);
                    //puzzles[i, j] = Instantiate(puzzlePrefabs[getPuzzleType], vector3, transform.rotation);

                    puzzles[i, j].transform.parent = transform;
                    Puzzle puzzle = puzzles[i, j].GetComponent<Puzzle>();
                    puzzle.SetUpType(getPuzzleType);
                    puzzle.GiveNewPosition(vector3);
                    puzzle.SetPositionInArray(new Vector2(i,j));*/


                    GameObject newPuzzle = PuzzleDictionary.Instance.GetPuzzle();
                    Vector3 childScale = newPuzzle.transform.localScale;
                    Vector3 vector3 = PositionForPuzzle(i + (i * childScale.x), j + (j * childScale.y));

                    puzzles[i, j] = Instantiate(newPuzzle, puzzlesPosition[i, height], transform.rotation);

                    puzzles[i, j].transform.parent = transform;
                    Puzzle puzzle = puzzles[i, j].GetComponent<Puzzle>();
                    puzzle.SetUpType(PuzzleDictionary.Instance.GetPuzzleType());
                    puzzle.GiveNewPosition(vector3);
                    puzzle.SetPositionInArray(new Vector2(i, j));
                }
            }
        }
        //Debug.Log("debugDestroyedPuzzles:" + debugDestroyedPuzzles);
    }

    //Player dont use finger
    #region ComputeUserFingers
    private void FingerUp()
    {
        playerGatheringPuzzleCount = 0;

        if (playerUseFinger == true)
        {
            // Delete actual line
            lineController.ResetLine();
            // Reset collecting order
            puzzleSelectedOrder = new List<Vector2>();

            foreach (GameObject puzzle in puzzles)
            {
                if (puzzle != null)
                {

                    Puzzle puzzleScript = puzzle.GetComponent<Puzzle>();
                    if (puzzleScript != null)
                    {
                        if (puzzleScript.GetIsPuzzleSelected())
                        {                    
                            playerGatheringPuzzleCount++;                      
                        }
                        
                        puzzleScript.SetPlayerDoesntUseFigner();
                        //puzzleScript.SetCantBeSelected();
                    }
                        
                }
            }

            if (playerGatheringPuzzleCount >= minPuzzleToGather)
            {
                DestroyPuzzlesInGrid();
            }

            playerUseFinger = false;       
            playerGatheringPuzzleType = -1;
           
        }
        
    }
    #endregion



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
            public const int grass = 1;
            public const int wheat = 2;
            public const int chicken = 3;
            public const int pig = 4;
            public const int carrot = 5;
            public const int tree = 6;

            //-- enemies 
            // farm
            const int rat = 14;
        }
        public abstract class puzzleMine
        {
            // mine
            public const int dirt = 7;
            public const int iron = 8;
            public const int stone = 9;
            public const int coal = 10;
            public const int gold = 11;
            public const int silver = 12;
            public const int diamond = 13;

            // mine
            const int lava = 15;
        }

    }
}
