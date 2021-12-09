using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
    // Start is called before the first frame update
    public Text moneyText;
    public MaterialsController materialsController;
    void Start()
    {
        materialsController=GameObject.Find("TownHall").GetComponent<MaterialsController>();
        moneyText=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = materialsController.playersMoney.ToString();//counter.ToString();
    }
}
