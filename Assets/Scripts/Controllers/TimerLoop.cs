using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLoop : MonoBehaviour
{
    [SerializeField]
    public bool takeGold;
    public int goldCount;

    private float nextActionTime;
    private float nextAddTime;
    public float periodAdd;
    public float period;
    public MaterialsController materialsController;
    public GetGold getGold;
    // public MaterialsController materialsController;
    // Start is called before the first frame update
    void Start()
    {
        takeGold = false;
        getGold = GetComponent<GetGold>();
        materialsController = GetComponent<MaterialsController>();
        nextActionTime = 0.0f;
        period = 1.0f;
        periodAdd = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            goldCount += 2;
            if (Time.time > nextAddTime)
            {
                nextAddTime += periodAdd;
                //getGold.active_=true; problem

                // goldCount += 4;
                // takeGoldBTN.SetActive(true);
                // execute block of code here
            }
            // execute block of code here
        }

        if (takeGold == true)
        {
            materialsController.playersGold = goldCount;
            takeGold = false;
        }
    }
}
