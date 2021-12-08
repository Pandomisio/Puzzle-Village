using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private int type;

    BoxCollider2D collider2D;
    private void Start()
    {
        collider2D = GetComponentInChildren<BoxCollider2D>();
        if (collider2D != null)
            Debug.Log("We have a collider of puzzle");
        else
            Debug.Log("We don't have a collider of puzzle");
    }


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
        // TODO
    }

    //-- Czy nie pod³¹czyæ tego do odjêcia palca? event?
    public void unFadePuzzle()
    {
        // TODO
    }

    private void OnMouseOver()
    {
        // Destroy (this.gameObject);
        Debug.Log("You clicked our puzzle");
    }      
    
    private void OnMouseExit()
    {
        Debug.Log("You unclicked our puzzle");
    }
    

}
