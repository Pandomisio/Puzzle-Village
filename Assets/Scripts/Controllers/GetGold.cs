using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GameObject))]

public class GetGold : MonoBehaviour
{
    // Start is called before the first frame update
    public TimerLoop timerLoop;
    public GameObject getGold;

    public bool active_;
    void Start()
    {
        active_=false;
        getGold = GetComponent<GameObject>();
        timerLoop = GetComponent<TimerLoop>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("Złoto zebrane!");
        //    //timerLoop.takeGold=true; problem
        //     getGold.SetActive(false);
        // }
    }
}

