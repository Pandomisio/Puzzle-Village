using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private int type;

    private void Start()
    {
        
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
        //Debug.Log("You clicked our puzzle");
    }      
    
    private void OnMouseExit()
    {
        //Debug.Log("You unclicked our puzzle");
    }
    

}
