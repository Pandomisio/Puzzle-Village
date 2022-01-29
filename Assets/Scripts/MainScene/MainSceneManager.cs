using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{

    [SerializeField] HousesAssets _housesAssets;
    [SerializeField] ResourcesAssets _resAssets;

    Dictionary<int, int> _preparedDictionaryOfHouses;


    // Start is called before the first frame update
    public static MainSceneManager Instance;
    void Start()
    {
        Instance = this;

        Dictionary<int, int> houses = new Dictionary<int, int>();
        for (int i = 3; i < 4; i++)
        {
            houses.Add(i, 3);
        }
        //HousesManager.InitBuildings(houses);
    }
    #region BuildingUI Handlers
    public List<House_GridElementData> GetPreparedDictionaryOfHouses()
    {
        Dictionary<int, int> buildedHouses = HousesManager.GetBuildedHouses();
        _preparedDictionaryOfHouses = new Dictionary<int, int>();
        // Wczytaæ wszystkie budynki
        // Sprawdzaæ czy go wybudowaliœmy
        // Jak tak o ustawiæ lvl

        if (buildedHouses != null)
        {
            foreach (var house in _housesAssets._buildings)
            {
                int id = (int)house._enumType;

                // 0 is none building
                if (id != 0)
                {
                    if (buildedHouses.ContainsKey(id))
                        _preparedDictionaryOfHouses.Add(id, buildedHouses[id]);
                    else
                        _preparedDictionaryOfHouses.Add(id, 1);
                }
          
            }
        }
        else
        {
            foreach (var house in _housesAssets._buildings)
            {
                int id = (int)house._enumType;
                if (id != 0)
                    _preparedDictionaryOfHouses.Add(id, 1);
            }
        }
        

        List<House_GridElementData> house_GridElementDatas = new List<House_GridElementData>();

        //Debug.Log(_preparedDictionaryOfHouses.Count);
        foreach(var house in _preparedDictionaryOfHouses)
        {
            int id = house.Key;
            //Debug.Log(((HousesAssets.BuildingType)house.Key).ToString() + " " + id);
            Sprite sprite = _housesAssets._buildings[id]._sprite;
            house_GridElementDatas.Add(new House_GridElementData(
                id,
                ((HousesAssets.BuildingType)house.Key).ToString(),
                sprite,
                "EMPTY DESCRIPTION"
                ));
        }

        return house_GridElementDatas;
    }
    public House_InfoHouseData GetSpecificHouseInfo(int id)
    {
        string name = ((HousesAssets.BuildingType)id).ToString();
        Debug.Log(name);
        Sprite houseSprite = _housesAssets._buildings[id]._sprite;
        List<ResourcesForHouse> resources = new List<ResourcesForHouse>();
        // Get list of res for specific lvl
        List<HousesAssets.RequireResources> resourcesForBuidling =
            _housesAssets._buildings[id]._levelsOfBuilding[_preparedDictionaryOfHouses[id] - 1]._requireResources;
        //Debug.Log("Resource needed:");
        // Iterate required resources
        foreach ( var resource in resourcesForBuidling)
        {
            // Get sprite from resAssets of res id from resourcesForBuidling
            Sprite resSprite = _resAssets._resources[(int)resource._requiredResource]._icon;

            resources.Add(new ResourcesForHouse(resSprite , resource._amountOfResource));
            Debug.Log( resource._requiredResource.ToString() + " " + resource._amountOfResource);
        }
        
        House_InfoHouseData house = new House_InfoHouseData(
            houseSprite,
            name,
            "EMPTY DESCRIPTION",
            resources
            );
        
        return house;
    }

    public struct House_GridElementData
    {
        public House_GridElementData(int id ,string name , Sprite sprite, string description)
        {
            _id = id;
            _icon = sprite;
            _name = name;
            _description = description;
        }

        public int _id;
        public Sprite _icon;
        public string _name;
        public string _description;
    }


    public struct House_InfoHouseData
    {
        public House_InfoHouseData(Sprite icon,string name,string description, List<ResourcesForHouse> resourcesForHouses)
        {
            _description = description;
            _icon = icon;
            _name = name;
            _resourcesForHouses = resourcesForHouses;
        }
        public Sprite _icon;
        public string _name;
        public string _description;
        public List<ResourcesForHouse> _resourcesForHouses;
    }
    public struct ResourcesForHouse
    {
        public ResourcesForHouse(Sprite sprite, int quantity)
        {
            _sprite = sprite;
            _quantity = quantity;
        }
        public Sprite _sprite;
        public int _quantity;
    }
    #endregion
}
