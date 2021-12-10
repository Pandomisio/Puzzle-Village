using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    // Steps
    // 1.After clicking first puzzle disable other ( fade and turn off colliders )
    // 2.


    [SerializeField] private int type;
    [SerializeField] private float downSizeScale = 0.35f;

    private Vector3 defaultScale;

    private puzzleGrid grid;
    private bool playerUseFinger;
    private bool isSelectedPuzzle;

    private void Start()
    {
        defaultScale = transform.localScale;

        grid = GetComponentInParent<puzzleGrid>();
        if (grid == null)
            Debug.LogError("No puzzleGrid componnent");
    }
    private void Update()
    {
        if (!playerUseFinger)
        {
            unFadePuzzle();
            unSelectPuzzle();
        }
            
    }

    public void SetUpType(int type) => this.type = type;
    public void PlayerDoesntUseFigner() => playerUseFinger = false;
    public void PlayerUseFinger() => playerUseFinger = true;
    public bool IsPuzzleSelected() => isSelectedPuzzle; 


    public bool IsSelectedTypePuzzle(int type)
    {
        // If im the same type of selected puzzle dont fade me
        if (this.type == type)
            return true;
        else
            return false;
    }

    private void SelectedPuzzle()
    {
        // Scale it a bit down
        transform.localScale = new Vector3(downSizeScale, downSizeScale, downSizeScale);
        isSelectedPuzzle = true;
    }

    private void unSelectPuzzle()
    {
        isSelectedPuzzle = false;
    }


    public void FadePuzzle()
    {
        // Transparency
        Color color = GetComponentInChildren<SpriteRenderer>().color;
        color.a = .6f;
        GetComponentInChildren<SpriteRenderer>().color = color;
        // Scale it a bit down
        transform.localScale = new Vector3(downSizeScale, downSizeScale, downSizeScale);
        // Disable collider
        GetComponentInChildren<Collider2D>().enabled = false;
    }
    public void unFadePuzzle()
    {
        // Bring Transparency back
        Color color = GetComponentInChildren<SpriteRenderer>().color;
        color.a = 1f;
        GetComponentInChildren<SpriteRenderer>().color = color;
        // Bring scaling back
        transform.localScale = defaultScale;
        // Enable collider
        GetComponentInChildren<Collider2D>().enabled = true;
    }

    public void OnMouseDown()
    {
        // Destroy (this.gameObject);
        Debug.Log("You clicked our puzzle");
        grid.FadeTypeOfPuzzle(type);
        //FadePuzzle();
    }

    private void OnMouseOver()
    {
        if (playerUseFinger)
            SelectedPuzzle();
        //Debug.Log("You Over our puzzle");
        //FadePuzzle();
    }

    private void OnMouseExit()
    {
        //Debug.Log("You unclicked our puzzle");
        if ( !playerUseFinger )
            unFadePuzzle();
    }

   

}
