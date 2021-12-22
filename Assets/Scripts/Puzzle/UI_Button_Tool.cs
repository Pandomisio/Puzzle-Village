using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_Tool : MonoBehaviour
{
    int toolType;
    // public ToolType tools = new ToolType();
    public ToolsManager.toolType toolTypes = new ToolsManager.toolType();

    private Button _btn;
    private Text _text;

    void Awake()
    {
        //toolType = 2;
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(UseTool);
        _text = _btn.GetComponentInChildren<Text>();

        //Debug.Log(toolTypes.ToString());    
        //Debug.Log((int)System.Enum.Parse(typeof(ToolsManager.toolType), toolTypes.ToString()));
        toolType = (int)System.Enum.Parse( typeof(ToolsManager.toolType) , toolTypes.ToString() );

        UI_Manager.triggerInitToolsCounter += UI_AddToTriggerToUpdate;
    }

    private void UI_AddToTriggerToUpdate()
    {
        UI_Manager._instance.UI_InitAmountOfTool(toolType, this);
    }

    public void UseTool()
    {
        //Debug.Log("We used UseTool with addListener");
        UI_Manager._instance.UseTool(toolType,this);
    }

    public void UpdateAmount(int amount , int maxTools)
    {
        /*_text.text = "Rake: " +  amount + " / " + maxTools;*/
        _text.text = toolTypes.ToString() + " " + amount + " / " + maxTools;
    }

}
