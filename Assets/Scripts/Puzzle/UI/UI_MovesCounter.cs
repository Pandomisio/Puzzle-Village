using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MovesCounter : MonoBehaviour
{
    public static UI_MovesCounter _instance;
    

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public void UpdateCounter(short x , short y)
    {
        // Update text
    }
    
}
