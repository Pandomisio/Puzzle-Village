using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLoop : MonoBehaviour
{
    [SerializeField]
    public bool moneyTaken;
    public float moneyIncrease;

    private float nextActionTime;
    private float nextAddTime;
    public float periodAdd;
    public float period;
    public float loopTime;
    public MaterialsController materialsController;
    public GetMoney getMoney;
    public GameObject showBTN;
    // public MaterialsController materialsController;
    // Start is called before the first frame update
    void Start()
    {
        showBTN = GameObject.Find("TakeMoneyBTN").GetComponent<GameObject>();
        moneyTaken = false;
        getMoney = GameObject.Find("TakeMoneyBTN").GetComponent<GetMoney>();
        materialsController = GetComponent<MaterialsController>();
        nextActionTime = 0.0f;
        period = 1.0f;
        //periodAdd = 30f;
        loopTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            moneyIncrease += 0.3132f;
            // if (Time.time > nextAddTime)
            // {
            //     nextAddTime += periodAdd;
                loopTime++;
                if (loopTime == 10)
                {
                    Debug.Log(getMoney.canTakeMoney);
                    getMoney.canTakeMoney = true;
                    showBTN.SetActive(getMoney.canTakeMoney);
                    Debug.Log(getMoney.canTakeMoney);
                }
            // }
        }

        if (moneyTaken == true)
        {
            if(moneyIncrease%10>=0.5f){
                moneyIncrease=Mathf.RoundToInt(moneyIncrease);
            }
            else{
                moneyIncrease=Mathf.FloorToInt(moneyIncrease);
            }
            materialsController.playersMoney += (int)moneyIncrease;
            moneyIncrease = 0;
            loopTime = 0;
            showBTN.SetActive(getMoney.canTakeMoney);
            moneyTaken = false;
        }
    }
}
