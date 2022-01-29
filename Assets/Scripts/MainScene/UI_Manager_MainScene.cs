using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_MainScene : MonoBehaviour
{
    public static UI_Manager_MainScene Instance;

    // Action buttons
    [SerializeField] CanvasGroup _bottomButtons;
    // Info
    [SerializeField] CanvasGroup _topInfo;
    // Tabs
    [SerializeField] CanvasGroup _resourcesTab;
    [SerializeField] CanvasGroup _housesToBuildTab;
    [SerializeField] CanvasGroup _marketTab;
    [SerializeField] CanvasGroup _placesForHous;

    void Start()
    {
        if (Instance == null)
            Instance = this;
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
                    _topInfo.gameObject.SetActive(true);
                    break;
                }
            case UI_Element.market:
                {
                    _marketTab.gameObject.SetActive(false);
                    _bottomButtons.gameObject.SetActive(true);
                    break;
                }
            case UI_Element.buildHouse:
                {
                    _housesToBuildTab.gameObject.SetActive(false);
                    _placesForHous.gameObject.SetActive(false);
                    _bottomButtons.gameObject.SetActive(true);
                    _topInfo.gameObject.SetActive(true);
                    break;
                }


        }
    }
    public void OpenUpWindow(UI_Element tabType, params object[] objects)
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
                    _topInfo.gameObject.SetActive(false);
                    break;
                }
            case UI_Element.market:
                {
                    _marketTab.gameObject.SetActive(true);
                    _bottomButtons.gameObject.SetActive(false);
                    break;
                }
            case UI_Element.buildHouse:
                {
                    Debug.Log(objects[0]);
                    _housesToBuildTab.gameObject.SetActive(false);
                    _placesForHous.gameObject.SetActive(true);
                    _placesForHous.gameObject.GetComponent<UI_PlaceHouse>().SetPlacingHouseIcon(objects[0] as Sprite);
                    _bottomButtons.gameObject.SetActive(false);
                    _topInfo.gameObject.SetActive(false);
                    break;
                }


        }
    }

    public enum UI_Element
    {
        resource,
        housesToBuilt,
        market,
        buildHouse
    }

}
