using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BottomButtons : MonoBehaviour
{
    [SerializeField] Button _resourcesButton;
    [SerializeField] Button _housesToBuildButton;
    [SerializeField] Button _marketButton;


    UI_Manager_MainScene _ui_Manager;

   // public UI_Manager_MainScene.UI_Element _tabType = new UI_Manager_MainScene.UI_Element();

    void Start()
    {
        _resourcesButton.onClick.AddListener(ResourcesButton);
        _housesToBuildButton.onClick.AddListener(HousesToBuild);
        _marketButton.onClick.AddListener(Market);

        _ui_Manager = transform.parent.GetComponent<UI_Manager_MainScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResourcesButton() => _ui_Manager.OpenUpWindow(UI_Manager_MainScene.UI_Element.resource);
    public void HousesToBuild() => _ui_Manager.OpenUpWindow(UI_Manager_MainScene.UI_Element.housesToBuilt);
    public void Market() => _ui_Manager.OpenUpWindow(UI_Manager_MainScene.UI_Element.market);



}
