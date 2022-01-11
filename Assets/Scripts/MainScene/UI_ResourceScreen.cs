using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ResourceScreen : MonoBehaviour
{
    Dictionary<int, int> _resources;
    [SerializeField] ResourcesAssets _resourcesAssets;
    [SerializeField] GameObject _gridParent;
    [SerializeField] GameObject _gridElement;

    void OnEnable()
    {
        //Debug.Log("PrintOnEnable: script was enabled");

        // TO DEBUG
        Dictionary<int,int> resources = new Dictionary<int, int>();
        for ( int i = 3; i < 9; i++ )
        {
            resources.Add(i, 5);
            ResourcesManager.InitResources(resources);
        }
        
        _resources = ResourcesManager.GetPlayerResorces();
        DisplayResources();
    }
    void OnDisable()
    {
        //foreach ( Transform child in _gridParent.GetComponent<RectTransform>().transform )
        foreach (Transform child in _gridParent.transform)
        {
            //child.setActive(false);
            Destroy(child.gameObject);
            //Destroy(child);
        }
    }
    void DisplayResources()
    {
        if (_resources == null)
            return;
        foreach (var resource in _resources)
        {
            //Debug.Log(_sprites.sprites);
            // We need to get icon for that resource
            Sprite iconOfResource = null;
            foreach (var sprite in _resourcesAssets._resources)
            {
                if ( resource.Key == (int)sprite._enumType )
                {
                    iconOfResource = sprite._icon;
                    Debug.Log("We have an icon for " + resource.Key + " Enumtype value" + (int)sprite._enumType );
                    break;
                }
            }
            if (iconOfResource == null)
                Debug.Log("No icon for " + resource.Key);
            // We have an resource and icon for it
            // New element
            GameObject _newElement = Instantiate(_gridElement);
            // Place in grid
            _newElement.GetComponent<RectTransform>().SetParent(_gridParent.GetComponent<RectTransform>().transform);
            _newElement.GetComponent<RectTransform>().localScale = Vector3.one;
           // Set up
           _newElement.GetComponent<UI_ResourceGridElement>().SetUpElement(
                iconOfResource, resource.Value, resource.Key.ToString() );           
        }
    }
    

}
