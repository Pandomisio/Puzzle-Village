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
    private bool canBeSelected;

    [SerializeField] private float speed = .25f;
    private float journeyLength;
    private float startTime;

    private Vector2 newLocation;
    private Vector2 posInArray;
    
    
    private void Awake()
    {
        newLocation = transform.localPosition;
    }

    private void Start()
    {
        defaultScale = transform.localScale;
        playerUseFinger = false;
        //newLocation = transform.localPosition

        grid = GetComponentInParent<puzzleGrid>();
        if (grid == null)
            Debug.LogError("No puzzleGrid componnent");
    }
    private void Update()
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
    //
    public void PlayerDoesntUseFigner() => playerUseFinger = false;
    public void PlayerUseFinger() => playerUseFinger = true;
    
    public void SetPositionInArray(Vector2 posInArray) => this.posInArray = posInArray;
    //
    public void CanBeSelected()
    {
        if ( !isSelectedPuzzle)
            canBeSelected = true;
    }
    public void CantBeSelected() => canBeSelected = false;
    public bool IsPuzzleSelected() => isSelectedPuzzle;
    private void unSelectPuzzle() => isSelectedPuzzle = false;
    //
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

    #region Fade / Unfade puzzle
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
    #endregion

    #region OnMouse Actions
    private void OnMouseDown()
    {
        grid.FadeTypeOfPuzzle(type);
        grid.ActivatePuzzlesAround(posInArray);
        //this.canBeSelected = true;
    }

    private void OnMouseOver()
    {
        if (playerUseFinger && canBeSelected && !isSelectedPuzzle)
        {
            SelectedPuzzle();
            grid.ActivatePuzzlesAround(posInArray);
        }
            
    }

    private void OnMouseExit()
    {
        if ( !playerUseFinger )
            unFadePuzzle();
    }

    #endregion


}
