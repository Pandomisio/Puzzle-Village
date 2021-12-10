using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private int type;
    [SerializeField] private float downSizeScale = 0.35f;

    private Vector3 defaultScale;

    private puzzleGrid grid;
    private bool playerUseFinger;

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
            unFadePuzzle();
    }

    public void SetUpType(int type) => this.type = type;
    public void PlayerFingerUp() => playerUseFinger = false;
    public void PlayerFingerDown() => playerUseFinger = true;


    public bool isSelectedPuzzle(int type)
    {
        // If im the same type of selected puzzle dont fade me
        if (this.type == type)
            return true;
        else
            return false;
    }

    public void FadePuzzle()
    {
        // Transparency
        Color color = GetComponentInChildren<SpriteRenderer>().color;
        color.a = .6f;
        GetComponentInChildren<SpriteRenderer>().color = color;
        // Scale it a bit down
        transform.localScale = new Vector3(.35f, .35f, .35f);
    }

    //-- Czy nie pod³¹czyæ tego do odjêcia palca? event?
    public void unFadePuzzle()
    {
        // Bring Transparency back
        Color color = GetComponentInChildren<SpriteRenderer>().color;
        color.a = 1f;
        GetComponentInChildren<SpriteRenderer>().color = color;
        // Bring scaling back
        transform.localScale = defaultScale;
    }

    private void OnMouseDown()
    {
        // Destroy (this.gameObject);
        //Debug.Log("You clicked our puzzle");
        grid.FadeTypeOfPuzzle(type);
        //FadePuzzle();
    }

    private void OnMouseOver()
    {
        if (playerUseFinger)
            Debug.Log("Another puzzle");
    }

    private void OnMouseExit()
    {
        //Debug.Log("You unclicked our puzzle");
        if ( !playerUseFinger )
            unFadePuzzle();
    }

   

}
