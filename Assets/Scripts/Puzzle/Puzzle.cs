using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private int type;
    [SerializeField] private float downSizeScale = 0.35f;
    
    private Vector3 defaultScale;
    
    private puzzleGrid grid;
    private bool playerUseFinger;
    private bool isSelectedPuzzle;

    [SerializeField] private float speed = .25f;
    private float journeyLength;
    private float startTime;

    public Vector2 newLocation;
    public bool changedPos;
    
    void Awake()
    {
        newLocation = transform.localPosition;
    }

    public void Start()
    {
        changedPos = false;
        defaultScale = transform.localScale;
        //newLocation = transform.localPosition

        grid = GetComponentInParent<puzzleGrid>();
        if (grid == null)
            Debug.LogError("No puzzleGrid componnent");
    }
    public void Update()
    {
        if (!playerUseFinger)
        {
            unFadePuzzle();
            unSelectPuzzle();
        }
        
        if (newLocation != Vector2.zero)
        {      
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.localPosition, newLocation, fractionOfJourney);
        }


    }

    public void SetUpType(int type) => this.type = type;
    public void PlayerDoesntUseFigner() => playerUseFinger = false;
    public void PlayerUseFinger() => playerUseFinger = true;
    public bool IsPuzzleSelected() => isSelectedPuzzle;
    private void unSelectPuzzle() => isSelectedPuzzle = false;
    public void GiveNewPosition(Vector2 newPos)
    {     
        newLocation = newPos;
        journeyLength = Vector3.Distance(transform.position, newLocation);
        startTime = Time.time;
    }

    public bool IsSelectedTypePuzzle(int type)
    {
        // If im the same type of selected puzzle dont fade me
        if (this.type == type)
            return true;
        else
            return false;
    }

    private void SelectedPuzzle()
    {
        // Scale it a bit down
        transform.localScale = new Vector3(downSizeScale, downSizeScale, downSizeScale);
        isSelectedPuzzle = true;
    }
    public void FadePuzzle()
    {
        // Transparency
        Color color = GetComponentInChildren<SpriteRenderer>().color;
        color.a = .6f;
        GetComponentInChildren<SpriteRenderer>().color = color;
        // Scale it a bit down
        transform.localScale = new Vector3(downSizeScale, downSizeScale, downSizeScale);
        // Disable collider
        GetComponentInChildren<Collider2D>().enabled = false;
    }
    public void unFadePuzzle()
    {
        // Bring Transparency back
        Color color = GetComponentInChildren<SpriteRenderer>().color;
        color.a = 1f;
        GetComponentInChildren<SpriteRenderer>().color = color;
        // Bring scaling back
        transform.localScale = defaultScale;
        // Enable collider
        GetComponentInChildren<Collider2D>().enabled = true;
    }

    public void OnMouseDown()
    {
        // Destroy (this.gameObject);
        //Debug.Log("You clicked our puzzle");
        grid.FadeTypeOfPuzzle(type);
        //FadePuzzle();
    }

    private void OnMouseOver()
    {
        if (playerUseFinger)
            SelectedPuzzle();
        //Debug.Log("You Over our puzzle");
        //FadePuzzle();
    }

    private void OnMouseExit()
    {
        //Debug.Log("You unclicked our puzzle");
        if ( !playerUseFinger )
            unFadePuzzle();
    }

   

}