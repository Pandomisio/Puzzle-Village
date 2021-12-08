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
    public abstract class puzzlesGamesTypes
    {
        //-- classic
        public const int farm = 1;
        public const int mine = 2;
    }

    public abstract class puzzlesTypes
    {
        //-- classic
        // farm
        public const int grass = 1;
        public const int wheat = 2;
        public const int chicken = 3;
        public const int pig = 4;
        public const int carrot = 5;
        public const int tree = 6;

        // mine
        public const int dirt = 7;
        public const int iron = 8;
        public const int stone = 9;
        public const int coal = 10;
        public const int gold = 11;
        public const int silver = 12;
        public const int diamond = 13;

        //-- enemies 
        // farm
        const int rat = 14;

        // mine
        const int lava = 15;

    }

}
