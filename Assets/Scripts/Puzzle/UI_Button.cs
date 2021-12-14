using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [SerializeField] int toolType;

    private Button btn;


    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(UseTool);
    }


    public void UseTool()
    {
        Debug.Log("We used UseTool with addListener");
        UI_Manager.instance.UseTool(toolType);
    }
}
