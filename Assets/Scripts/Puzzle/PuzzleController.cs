using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{

    [SerializeField] private int width, height;

    private puzzleGrid puzzleGrid;

    // Steps
    // 1. Create a grid
    // 2. Init grid
    void Start()
    {
        //puzzleGrid = new puzzleGrid(width, height);
    }

    // Update is called once per frame
    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.Mouse0))
            FingerDown(); // Using finger
        else
            FingerUp();  // Not using
    }

    private void FingerUp()
    {
        // Check if player marked some puzzles to gather


        /*if (fingerPressed != true)
        {
            foreach (GameObject puzzle in puzzles)
            {
                Puzzle puzzleScript = puzzle.GetComponent<Puzzle>();
                if (puzzleScript != null)
                    puzzleScript.PlayerFingerUp();
            }
            fingerPressed = true;
        }*/

    }
    private void FingerDown()
    {
        /*if (fingerPressed != false)
        {
            foreach (GameObject puzzle in puzzles)
            {
                Puzzle puzzleScript = puzzle.GetComponent<Puzzle>();
                if (puzzleScript != null)
                    puzzleScript.PlayerFingerDown();
            }

            fingerPressed = false;
        }*/
    }
}
