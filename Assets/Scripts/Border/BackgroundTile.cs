using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
    public GameObject[] puzzles;
    private string tempname;

    public int type;
    public int clickedType;
    // Start is called before the first frame update

    public string firstPuzzle;//pierwszy zaznaczony puzel
    public string lastPuzzle;//ostatni zaznaczony puzel
    // public string[] selectedPuzzles;//tablica zaznaczonych puzzli
    public OnPuzzelClick onPuzzelClick;
    public int countPuzzles = 0;

    public bool mouseOver = false;

    void Start()
    {
        onPuzzelClick = GameObject.Find("Board").GetComponent<OnPuzzelClick>();
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

        // onClickPuzzle();
        if ((type == onPuzzelClick.selectedType) && (onPuzzelClick.selectedType != -1))
        {
            onPuzzelClick.selectedPuzzles.Add(tempname);
        }
    }
    void Initialize()
    {
        int puzzleToUse = Random.Range(0, puzzles.Length);
        type = puzzleToUse;
        GameObject puzzle = Instantiate(puzzles[puzzleToUse], transform.position, Quaternion.identity);
        puzzle.transform.parent = this.transform;
        puzzle.name = this.gameObject.name;
        tempname = puzzle.name;

        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
    }
    void OnMouseDown()
    {
        // this object was clicked - do something
        //Destroy (this.gameObject);
        mouseOver = !mouseOver;
        // Debug.Log(tempname.GetType());
        firstPuzzle = tempname;
        // selectedPuzzles[0] = tempname;
        onPuzzelClick.selectedPuzzles.Add(tempname);
        if (onPuzzelClick.selectedType == -1)
            onPuzzelClick.selectedType = type;

        countPuzzles++;

        Destroy(this.gameObject);
        Debug.Log(type);
        Debug.Log(onPuzzelClick.selectedType);
    }

    // private void OnMouseDrag() {
    //     Debug.Log(tempname);
    // }
    // private void OnMouseDrag()
    // {
        //     {
        //         // Debug.Log(tempname);
        //         // Debug.Log(type);
        //         // if(clickedType==type){
        //         //     Debug.Log("Ten sam Typ!");
        //         // }
        //         // if (selectedPuzzles[countPuzzles] != tempname)
        //         // {
        //         //     selectedPuzzles[countPuzzles] = tempname;
        //         //     mouseOver = !mouseOver;
        //         //     countPuzzles++;
        //         // }

        //         if (type == onPuzzelClick.selectedType)
        //         {
        //             onPuzzelClick.selectedPuzzles.Add(tempname);
        //         }
        //     }
    // }
    private void OnMouseUp()
    {
        clickedType = -1;
        mouseOver = !mouseOver;
        if (countPuzzles > 3)
        {


        }

        if (type == onPuzzelClick.selectedType)
        {
            for (int i = 0; i < onPuzzelClick.selectedPuzzles.Count; i++)
            {
                // Destroy(this.gameObject);
                BackgroundTile backgroundTile = GameObject.Find(tempname.ToString()).GetComponent<BackgroundTile>();
                Destroy(backgroundTile);
            }

        }


        // for(int i=0;i<countPuzzles;i++){
        //      Debug.Log(selectedPuzzles[i]);
        // }
        onPuzzelClick.selectedType = -1;
        countPuzzles = 0;
    }
}
