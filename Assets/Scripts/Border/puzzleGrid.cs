using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class puzzleGrid : MonoBehaviour, IPointerDownHandler , IPointerUpHandler
{
    // Our prefabs
    public GameObject[] puzzlePrefabs;
    // Our puzzles
    public GameObject[,] puzzles;

    bool buttonPressed;

    // Todo Another class for chances Singleton i guess
    [SerializeField] private Dictionary <int,float> puzzleChances;

    [SerializeField] private int width, height;
    private void Start()
    {
        puzzles = new GameObject[width, height];

        InitPuzzleGrid();
    }

    private void InitPuzzleGrid()
    {
       for ( int i = 0; i < width; i++ )
       {
            for ( int j = 0; j < height; j++ )
            {
                int GetPuzzle = WhatPuzzleToGrid();

                Vector3 childScale = puzzlePrefabs[GetPuzzle].transform.localScale;
                Vector3 vector3 = PositionForPuzzle(i + ( i * childScale.x), j + (j * childScale.y) );

                // Init a prefab and make him a child
                puzzles[i, j] = Instantiate(puzzlePrefabs[GetPuzzle], vector3, transform.rotation);
                puzzles[i,j].transform.parent = transform;
            }
       }    
    }
    private int WhatPuzzleToGrid()
    {
        return puzzlesTypes.puzzleFarm.wheat;
    }


    private Vector3 PositionForPuzzle(float i , float j)
    {    
        return new Vector3(transform.position.x + i, transform.position.y + j, 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Somebody cliceked
        Debug.Log("Clicekd");
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // They unclicked
        Debug.Log("Unclicked");
        buttonPressed = false;
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
