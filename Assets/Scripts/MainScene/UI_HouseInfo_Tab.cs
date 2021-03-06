using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HouseInfo_Tab : MonoBehaviour
{

    [SerializeField] Image _iconImage;
    [SerializeField] Text _nameText;
    [SerializeField] Text _textDesrc;
    [SerializeField] Button _buttonClose;
    [SerializeField] Button _buttonBuild;
    
    public void SetUpElement(string name, string description, Sprite icon , List<MainSceneManager.ResourcesForHouse> requireResources)
    {
        _nameText.text = name;
        _textDesrc.text = description;
        _iconImage.sprite = icon;

        _buttonClose.onClick.AddListener( () => { Destroy(this.gameObject); });
        _buttonBuild.onClick.AddListener( () => {
            UI_Manager_MainScene.Instance.OpenUpWindow(UI_Manager_MainScene.UI_Element.buildHouse,_iconImage.sprite);
        });

        /*
        //Debug.Log("UI_Houseinfotab res:");
        foreach (var resource in requireResources)
        {
            //Debug.Log(resource._quantity);
        }
        */


    }
}
