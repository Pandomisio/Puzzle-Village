using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPuzzelClick : MonoBehaviour
{

    public List<string> selectedPuzzles;
    public int selectedType=-1;

    public string tempname;
    public int tempType;
    public int clickedType;
    public BackgroundTile backgroundTile;
    // Start is called before the first frame update
    void Start()
    {
        selectedType=-1;
        selectedPuzzles=new List<string>();
        backgroundTile=GetComponent<BackgroundTile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public void DestroyPuzzels(GameObject gamePuzzel){
    //     for(int i=0; i<selectedPuzzles.Count;i++){
    //         BackgroundTile tempPuzzel=GameObject.Find(selectedPuzzles[i].ToString()).GetComponent<BackgroundTile>();
    //         Destroy(GameObject.Find(selectedPuzzles[i].ToString()).GetComponent<BackgroundTile>());
    //     }
        
    // }
}
