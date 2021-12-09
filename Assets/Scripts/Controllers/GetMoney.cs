using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(GameObject))]

public class GetMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public TimerLoop timerLoop;
    //public GameObject getMoney;
    public Button getMoneyBtn;
    public bool canTakeMoney;

    void Start()
    {
        canTakeMoney = false;
        getMoneyBtn = getMoneyBtn.GetComponent<Button>();
        //btn = GameObject.FindWithTag("TakeGold");
        //getMoney = GetComponent<GameObject>();
        // getMoney = GameObject.FindWithTag("TakeGold");
        // timerLoop = GetComponent<TimerLoop>();
        timerLoop = FindObjectOfType<TimerLoop>();
        getMoneyBtn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("Złoto zebrane!");
        //timerLoop.takeGold=true; problem
        //btn.SetActive(false);
        timerLoop.moneyTaken = true;
        canTakeMoney = false;
        // Destroy(btn);
    }
    // Update is called once per frame
    void Update()
    {

    }

}

