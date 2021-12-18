using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [SerializeField] int toolType;

    private Button _btn;
    private Text _text;

    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(UseTool);
        _text = _btn.GetComponentInChildren<Text>();

        UI_Manager.triggerInitToolsCounter += InitTool;
    }

    private void InitTool()
    {
        UI_Manager._instance.GetAmountOfTool(toolType, this);
    }

    public void UseTool()
    {
        //Debug.Log("We used UseTool with addListener");
        UI_Manager._instance.UseTool(toolType,this);
    }

    public void UpdateAmount(int amount , int maxTools)
    {
        _text.text = "Rake: " +  amount + " / " + maxTools;
    }
}
