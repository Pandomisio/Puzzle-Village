 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsController : MonoBehaviour
{
    public int playersGold;
    public int playersGlory;
    public int playersPremium;
    public int playersWood;
    public int playersRock;

    private int[] playerMaterials;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetResource(int index )
    {
        playerMaterials[index]++;
    }
}
