using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BuildHouses_Tab : MonoBehaviour
{
    //Dictionary<int, int> _preparedDictionary;
    [SerializeField] HousesAssets _housesAssets;
    [SerializeField] GameObject _gridParent;
    [SerializeField] GameObject _gridElement;
    [SerializeField] GameObject _houseInfoTab;

    GameObject _openedHouseInfo;

    void OnEnable()
    {
        DisplayRes();
    }
    void OnDisable()
    {
        if (_openedHouseInfo != null)
            Destroy(_openedHouseInfo.gameObject);
        //foreach ( Transform child in _gridParent.GetComponent<RectTransform>().transform )
        foreach (Transform child in _gridParent.transform)
        {
            //child.setActive(false);
            Destroy(child.gameObject);
            //Destroy(child);
        }
    }
    void DisplayRes()
    {
        List<MainSceneManager.House_GridElementData> houses = MainSceneManager.Instance.GetPreparedDictionaryOfHouses();
        foreach (var house in houses)
        {
            GameObject _newElement = Instantiate(_gridElement);
            // Place in grid
            _newElement.GetComponent<RectTransform>().SetParent(_gridParent.GetComponent<RectTransform>().transform);
            _newElement.GetComponent<RectTransform>().localScale = Vector3.one;
            // Set up
            _newElement.GetComponent<UI_Building_Grid_Element>().SetUpElement(
                house._id,
                house._icon,
                house._name,
                house._description,           
                this
                );
        }

    }
    /*
    Dictionary<int, int> PreparedDictionaryOfHouses(Dictionary<int,int> buildedHouses)
    {
        Dictionary<int,int> preparedDictionaryOfHouses = new Dictionary<int,int>();
        // Wczytaæ wszystkie budynki
        // Sprawdzaæ czy go wybudowaliœmy
        // Jak tak o ustawiæ lvl

        foreach (var house in _housesAssets._buildings)
        {
            int id = (int)house._enumType;      

            if (buildedHouses.ContainsKey(id))
                preparedDictionaryOfHouses.Add(id, buildedHouses[id]);
            else
                preparedDictionaryOfHouses.Add(id, 1);
        }

        return preparedDictionaryOfHouses;
    }

    void DisplayResources()
    {
        Debug.Log(_preparedDictionary);
        if (_preparedDictionary == null)
            return;
        foreach (var house in _preparedDictionary)
        {
            //Debug.Log(_sprites.sprites);
            // We need to get icon for that resource
            Sprite iconOfResource = null;
            foreach (var sprite in _housesAssets._buildings)
            {
                if (house.Key == (int)sprite._enumType)
                {
                    iconOfResource = sprite._sprite;
                    Debug.Log("We have an icon for " + house.Key + " Enumtype value" + (int)sprite._enumType);
                    break;
                }
            }
            if (iconOfResource == null)
                Debug.Log("No icon for " + house.Key);

            // We have an resource and icon for it
            // New element
            GameObject _newElement = Instantiate(_gridElement);
            // Place in grid
            _newElement.GetComponent<RectTransform>().SetParent(_gridParent.GetComponent<RectTransform>().transform);
            _newElement.GetComponent<RectTransform>().localScale = Vector3.one;
            // Set up
            _newElement.GetComponent<UI_Building_Grid_Element>().SetUpElement(
                house.Key,
                house.Value,
                iconOfResource,
                ((HousesAssets.BuildingType)house.Key).ToString()
                , " EMPTY DESCRIPTION " ,
                this
                );


            Debug.Log(((HousesAssets.BuildingType)house.Key).ToString());
        }
    }
    */
    public void OpenHouseInfo(int idOfHouseToShowInfo)
    {
        //Debug.Log(idOfHouseToShowInfo + "" + lvlOfThatHouse);
        MainSceneManager.House_InfoHouseData house = 
            MainSceneManager.Instance.GetSpecificHouseInfo(idOfHouseToShowInfo);

        GameObject _newElement = Instantiate(_houseInfoTab);
        // Place in grid
        _newElement.GetComponent<RectTransform>().SetParent(this.GetComponent<RectTransform>().transform);
        _newElement.GetComponent<RectTransform>().localScale = Vector3.one;
        _newElement.GetComponent<RectTransform>().localPosition = Vector3.zero;
        // Set up
        _newElement.GetComponent<UI_HouseInfo_Tab>().SetUpElement(
            house._name,
            house._description,
            house._icon,
            house._resourcesForHouses
            );
        _openedHouseInfo = _newElement;
    }
}
