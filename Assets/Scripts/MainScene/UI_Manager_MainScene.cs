using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_MainScene : MonoBehaviour
{
    // Action buttons
    [SerializeField] CanvasGroup _bottomButtons;
    // Info
    [SerializeField] CanvasGroup _topInfo;
    // Tabs
    [SerializeField] CanvasGroup _resourcesTab;
    [SerializeField] CanvasGroup _housesToBuildTab;
    [SerializeField] CanvasGroup _marketTab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseUpWindow(UI_Element tabType)
    {
        Debug.Log("CloseUpWindow " + tabType.ToString());
        switch (tabType)
            {
            case UI_Element.resource:
                {
                    _resourcesTab.gameObject.SetActive(false);
                    _bottomButtons.gameObject.SetActive(true);
                    break;
                }
            case UI_Element.housesToBuilt:
                {
                    _housesToBuildTab.gameObject.SetActive(false);
                    _bottomButtons.gameObject.SetActive(true);
                    break;
                }
            case UI_Element.market:
                {
                    _marketTab.gameObject.SetActive(false);
                    _bottomButtons.gameObject.SetActive(true);
                    break;
                }

        }
    }
    public void OpenUpWindow(UI_Element tabType)
    {
        Debug.Log("OpenUpWindow " + tabType.ToString());
        switch (tabType)
        {
            case UI_Element.resource:
                {
                    _resourcesTab.gameObject.SetActive(true);
                    _bottomButtons.gameObject.SetActive(false);
                    break;
                }
            case UI_Element.housesToBuilt:
                {
                    _housesToBuildTab.gameObject.SetActive(true);
                    _bottomButtons.gameObject.SetActive(false);
                    break;
                }
            case UI_Element.market:
                {
                    _marketTab.gameObject.SetActive(true);
                    _bottomButtons.gameObject.SetActive(false);
                    break;
                }


        }
    }

    public enum UI_Element
    {
        resource,
        housesToBuilt,
        market
    }

}
