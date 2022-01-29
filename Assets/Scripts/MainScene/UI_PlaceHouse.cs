using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlaceHouse : MonoBehaviour
{
    //GameObject[] _placesForHouse;
    public static UI_PlaceHouse Instance;
    [SerializeField] Button _exit;
    [SerializeField] GameObject _placeHolder;

    Sprite _sprite;


    private void Start()
    {
        if (Instance == null)
            Instance = this;
        _exit.onClick.AddListener(() =>{
            UI_Manager_MainScene.Instance.CloseUpWindow(UI_Manager_MainScene.UI_Element.buildHouse);
            this.gameObject.SetActive(false);
        });

    }

    private void OnEnable()
    {
        foreach (Transform child in _placeHolder.transform)
        {
            //Debug.Log(gameObject.name);
            child.gameObject.SetActive(true);
        }

        _exit.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        HidePlacesWithoutHouses();
        _exit.gameObject.SetActive(false);
    }
    public void HouseIsPlaced()
    {
        HidePlacesWithoutHouses();
        UI_Manager_MainScene.Instance.CloseUpWindow(UI_Manager_MainScene.UI_Element.buildHouse);
    }
    public void SetPlacingHouseIcon(Sprite sprite) => _sprite = sprite;

    public Sprite GetPlacingHouseIcon () => _sprite;

    private void HidePlacesWithoutHouses()
    {
        foreach (Transform child in _placeHolder.transform)
        {
            UI_PlaceForHouse place = child.GetComponent<UI_PlaceForHouse>();
            if (place != null)
            {
                Debug.Log(gameObject.name);
                if (!child.GetComponent<UI_PlaceForHouse>().IsHouseOnThisPlace())
                    child.gameObject.SetActive(false);
            }
            else
                child.gameObject.SetActive(false);
        }
    }



}
