using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class puzzleGrid : MonoBehaviour
{
    [SerializeField] int minPuzzleToGather = 3;
    // Our prefabs
    public GameObject[] puzzlePrefabs;
    // Our puzzles
    public GameObject[,] puzzles;
    private GameObject[] puzzlesToDelete;

    bool playerUseFinger;
    int playerGatheringPuzzleType;
    int playerGatheringPuzzleCount;

    // Todo Another class for chances Singleton i guess
    [SerializeField] private Dictionary <int,float> puzzleChances;

    [SerializeField] private int width, height;
    public void Start()
    {
        puzzles = new GameObject[width, height];
        puzzlesToDelete = new GameObject[width * height];

        InitPuzzleGrid();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            FingerDown();
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            FingerUp();
    }
    private void InitPuzzleGrid()
    {
       for ( int i = 0; i < width; i++ )
       {
            for ( int j = 0; j < height; j++ )
            {
                int getPuzzleType = WhatPuzzleToGrid();

                Vector3 childScale = puzzlePrefabs[getPuzzleType].transform.localScale;
                Vector3 vector3 = PositionForPuzzle(i + ( i * childScale.x), j + (j * childScale.y) );

                // Init a prefab and make him a child
                puzzles[i, j] = Instantiate(puzzlePrefabs[getPuzzleType], vector3, transform.rotation);
                puzzles[i,j].transform.parent = transform;
                puzzles[i, j].GetComponent<Puzzle>().SetUpType(getPuzzleType);
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
        return new Vector3(transform.position.x + i, transform.position.y + j, 0);
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
                    puzzleScript.PlayerUseFinger();

                    if (!puzzleScript.IsSelectedTypePuzzle(type))
                    {
                        puzzleScript.FadePuzzle();
                    }
                }
            }
        }
    }

    //Player dont use finger
    private void FingerUp()
    {
        // Check if player marked some puzzles to gather
        playerGatheringPuzzleCount = 0;

        if (playerUseFinger == true)
        {
            foreach (GameObject puzzle in puzzles)
            {
                if (puzzle != null)
                {
                    Puzzle puzzleScript = puzzle.GetComponent<Puzzle>();
                    if (puzzleScript.IsPuzzleSelected())
                    {
                        puzzlesToDelete[playerGatheringPuzzleCount] = puzzleScript.gameObject;
                        playerGatheringPuzzleCount++;
                    }

                    if (puzzleScript != null)
                        puzzleScript.PlayerDoesntUseFigner();
                }
            }
            // COunt System.Linq
            if (playerGatheringPuzzleCount >= minPuzzleToGather)
            {
                Debug.Log("Player selected: " + playerGatheringPuzzleCount + " minPuzzleToHather: " + minPuzzleToGather);
                foreach ( GameObject puzzle in puzzlesToDelete)
                    Destroy(puzzle);
            }

            playerUseFinger = false;

            Debug.Log(" Zebra�e� typ: " + playerGatheringPuzzleType + " w ilo�ci: " + playerGatheringPuzzleCount);

            playerGatheringPuzzleType = -1;
            

        }
        
    }

    // Player use finger
    // Used in fadeTypePuzzl not needed?
    private void FingerDown()
    {
        if (playerUseFinger == false)
        {
            foreach (GameObject puzzle in puzzles)
            {
                if (puzzle != null)
                {
                    Puzzle puzzleScript = puzzle.GetComponent<Puzzle>();

                    if (puzzleScript != null)
                        puzzleScript.PlayerUseFinger();
                }
            }

            playerUseFinger = true;
        }
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
