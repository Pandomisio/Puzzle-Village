using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlaceForHouse : MonoBehaviour
{
    bool _haveHouse = false;
    [SerializeField] Button _buttonHouse;
    [SerializeField] Sprite _icon;
    private void Start()
    {
        _buttonHouse.onClick.AddListener( () => {  
            _haveHouse = true;
            _icon = UI_PlaceHouse.Instance.GetPlacingHouseIcon();
            GetComponent<Image>().sprite = _icon;
            _buttonHouse.gameObject.SetActive(false);
            UI_PlaceHouse.Instance.HouseIsPlaced();
        });
    }

    private void OnEnable()
    {
        if (_haveHouse)
            GetComponent<Image>().color = Color.red;
    }

    public bool IsHouseOnThisPlace() => _haveHouse;

}
