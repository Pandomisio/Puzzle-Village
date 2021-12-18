using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_Tool : MonoBehaviour
{
    int toolType;
    // public ToolType tools = new ToolType();
    public PuzzleTools.toolType toolTypes = new PuzzleTools.toolType();

    private Button _btn;
    private Text _text;

    void Start()
    {
        toolType = 2;
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(UseTool);
        _text = _btn.GetComponentInChildren<Text>();

        // toolType = toolTypes;
        // toolType store what we chosed in inspector
        //toolTypes.ToString();
        Debug.Log((int)System.Enum.Parse(typeof(PuzzleTools.toolType), toolTypes.ToString()));
        toolType = (int)System.Enum.Parse( typeof(PuzzleTools.toolType) , toolTypes.ToString() );

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
