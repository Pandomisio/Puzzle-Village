using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleGrid 
{

    private int puzzleGameType;
    private Puzzle[,] puzzles;
    private Dictionary <int,float> puzzleChances;


    public puzzleGrid(int width , int hight , Dictionary <int, float> puzzleChances  , int puzzleGameType )
    {
        this.puzzleChances = puzzleChances;
        this.puzzleGameType = puzzleGameType;

        puzzles = new Puzzle[width, hight];

        initPuzzleGrid();
    }

    private void initPuzzleGrid()
    {
        foreach ( var puzzle in puzzles )
        {
            // Dla ka¿dego puzzla na podstawie dic puzzleChances wybrac jaki w danym miejscu ma byc puzel

        }
    }


    private class Puzzle
    {
        int type;

        public Puzzle(int type)
        {
            this.type = type;
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

    }
    public abstract class puzzlesGamesTypes
    {
        //-- classic
        public const int farm       = 1;
        public const int mine       = 2;
    }

    public abstract class puzzlesTypes
    {
        //-- classic
        // farm
        public const int grass      = 1;
        public const int wheat      = 2;
        public const int chicken    = 3;
        public const int pig        = 4;
        public const int carrot     = 5;
        public const int tree       = 6;

        // mine
        public const int dirt       = 7;
        public const int iron       = 8;
        public const int stone      = 9;
        public const int coal       = 10;
        public const int gold       = 11;
        public const int silver     = 12;
        public const int diamond    = 13;

        //-- enemies 
        // farm
        const int rat        = 14;

        // mine
        const int lava       = 15;

    }
}
