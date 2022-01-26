using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Building_Grid_Element : MonoBehaviour
{
    [SerializeField] Image _iconImage;
    [SerializeField] Text _nameText;
    [SerializeField] Text _textDesrc;
    [SerializeField] Button _buttonMoreInfo;
    int _id;
    int _lvl;
    // Start is called before the first frame update
    public void SetUpElement(int id,Sprite icon, string name , string description, UI_BuildHouses_Tab parent)
    {
        _id = id;
        _nameText.text = name;
        _textDesrc.text = description;
        //_iconRenderer.sprite = _icon;
        _iconImage.sprite = icon;
        //_iconRenderer.
        ClickedInfoButton(parent);
    }

    private void ClickedInfoButton(UI_BuildHouses_Tab parent)
    {
        _buttonMoreInfo.onClick.AddListener(() => { parent.OpenHouseInfo(_id ); });
    }
}
