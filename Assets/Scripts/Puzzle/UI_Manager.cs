using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager _instance;

    private Dictionary<int, int> _amountOfTools;

    public static event Action triggerInitToolsCounter = delegate { };

    private short _maxTools = 5;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    #region usingTools

    public void SetAmountOfTools(Dictionary<int,int> tools)
    {
        _amountOfTools = tools;
        triggerInitToolsCounter();
    }
    

    public void GetAmountOfTool(int type, UI_Button tool)
    {
        tool.UpdateAmount(_amountOfTools[type],_maxTools);
    }
    
    
    public void UseTool(int type, UI_Button tool)
    {
        if (_amountOfTools[type] > 0)
        {
            if (puzzleManager.Instance.UsedTool(type))
            {
                // Player gather smth with tool
                _amountOfTools[type]--;
                Debug.Log("We used a tool");
                tool.UpdateAmount(_amountOfTools[type], _maxTools);
            }
            else
            {
                // Player get dont use a tool
            }
        }
        
    }

    #endregion

    #region MovesCounter

    private short _maxMoves;
    private short _moves;
    public void SetMoves(short moves)
    {
        _moves = moves;
        _maxMoves = moves;
        Debug.Log("Set maxMoves");     
    }
    

    public void PlayerMoved()
    {
        _moves--;
        Debug.Log("PlayerMoves moves:" + _moves + " / " + _maxMoves);
        if (_moves < 1)
        {
            EndPuzzleRound();
        }
        else
        {
            // Update our visual counter
            
            //UI_MovesCounter._instance.UpdateCounter(_moves,_maxMoves);
        }
    }

    public void EndPuzzleRound()
    {
        // ShowUp Summary
        Debug.Log("Max round reached");
    }

    #endregion
}
