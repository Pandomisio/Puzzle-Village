using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tilePrefab;
    public GameObject[] puzzles;
    private BackgroundTile[,] allTiles;

    public GameObject[,] allPuzzles;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        allPuzzles = new GameObject[width, height];
        SetUpBoard();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetUpBoard()
    {
        for (float i = 0; i < width; i += 1.25f)
        {
            for (float j = 0; j < height; j += 1.25f)
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity);
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "(" + i + "," + j + ")";
                int puzzleToUse=Random.Range(0,puzzles.Length);
                // GameObject puzzle = Instantiate(puzzles[puzzleToUse],tempPosition,Quaternion.identity);
                // puzzle.transform.parent=this.transform;
                // puzzle.name="(" + i + "," + j + ")";
            }
        }
    }
}
