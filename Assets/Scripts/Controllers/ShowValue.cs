using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
    // Start is called before the first frame update
    public Text counterText;
    public MaterialsController materialsController;
    void Start()
    {
        materialsController=GetComponent<MaterialsController>();
        counterText=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //counterText.text = materialsController.playersGold.ToString();//counter.ToString();
    }
}
