using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TabManager : MonoBehaviour
{
    [SerializeField] Button _exitBtn;
    UI_Manager_MainScene _ui_Manager;

    public UI_Manager_MainScene.UI_Element _tabType = new UI_Manager_MainScene.UI_Element();

    // Start is called before the first frame update
    void Start()
    {
        _ui_Manager = transform.parent.GetComponent<UI_Manager_MainScene>();

        _exitBtn.onClick.AddListener(CloseUpWindow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void CloseUpWindow()
    {
        Debug.Log("CloseUp Window");
        _ui_Manager.CloseUpWindow(_tabType);
    }


}
