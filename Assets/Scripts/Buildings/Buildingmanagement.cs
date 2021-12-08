using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildingmanagement : MonoBehaviour
{
    [SerializeField]
    //GameObject buildingname;
    Forge forge;
    // Start is called before the first frame update
    void Start()
    {
        //buildingname=GetComponent<GameObject>();
        //Debug.Log(this.buildingname.name);
        forge= new Forge();
        //building.ShowForge();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
