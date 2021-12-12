using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineController : MonoBehaviour
{
    public Material lineMaterial;

    private LineRenderer line;

    private int lineCounter;

    private List<Vector2> puzzleSelectedOrder;
    private Vector2 posToCorrect;


    private void Start()
    {
        lineCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player finger?
    }


    public void NewPuzzleSelected( Vector2 selectedPuzzlePosInArray)
    {
        if (line == null)                 
            NewLine(selectedPuzzlePosInArray);  
        
        line.positionCount++;

        Vector3 newPos = new Vector3(selectedPuzzlePosInArray.x - posToCorrect.x, selectedPuzzlePosInArray.y - posToCorrect.y, -1f);

        line.SetPosition(lineCounter, newPos);

        //Debug.Log("New line breakpoint: " + lineCounter + " On pos: " + selectedPuzzlePosInArray);

        lineCounter++;
            
        if (line.loop == true)
        {
            line.loop = false;
            //Debug.Log("line.loop value: " + line.loop);
        }

        
    }
    public void UnselectLastPuzzle()
    {
        line.positionCount--;
        lineCounter--;
    }
    public void ResetLine()
    {
        lineCounter = 0;

        if (line != null)
            Destroy(line.gameObject);
    }

    private void NewLine(Vector2 pos)
    {
        GameObject go = new GameObject();
        go.transform.position = pos;
        posToCorrect = pos;
        line = go.AddComponent<LineRenderer>();
        line.material = lineMaterial;
        
        line.positionCount = 0;
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.useWorldSpace = false;
        line.numCapVertices = 50;
        
    }
}
