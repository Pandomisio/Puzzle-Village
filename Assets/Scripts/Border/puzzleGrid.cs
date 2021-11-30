using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleGrid 
{
    private Puzzle[][] puzzles;

    Dictionary puzzleChances;


    public puzzleGrid(int width , int height , Dictionary puzzleChances <int,float> , int puzzleGameType)
    {
        this.puzzleChances = puzzleChances;

        puzzles = new puzzleGrid[width][height];
        initPuzzleGrid(puzzles,puzzleGameType);
    }

    private void initPuzzleGrid(Puzzle[][] puzzles, int type)
    {

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
    public interface puzzlesGamesTypes
    {
        //-- classic
        int static const farm      = 1;
        int static const mine       = 2;
    }

    public interface puzzlesTypes
    {
        //-- classic
        // farm
        int static const grass      = 1;
        int static const wheat      = 2;
        int static const chicken    = 3;
        int static const pig        = 4;
        int static const carrot     = 5;
        int static const tree       = 6;

        // mine
        int static const dirt       = 7;
        int static const iron       = 8;
        int static const stone      = 9;
        int static const coal       = 10;
        int static const gold       = 11;
        int static const silver     = 12;
        int static const diamond    = 13;

        //-- enemies 
        // farm
        int static const rat        = 14;

        // mine
        int static const lava       = 15;

    }
}
