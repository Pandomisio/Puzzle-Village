using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{

    private bool firstTouch, keepTouching, endTouching;

    private Vector2 previousTouch;
    // Start is called before the first frame update
    void Start()
    {
        firstTouch = false;
        keepTouching = false;
        endTouching = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                
                if (touch.phase == TouchPhase.Began)
                {
                    if (firstTouch == false)
                    {
                        //Debug.Log("Touch began");
                        endTouching = false;
                        firstTouch = true;
                        CastARay(touch);
                    }                
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    
                    Debug.Log("Touch moved");
                    keepTouching = true;
                    firstTouch = false;
                    CastARay(touch);
                    
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    if (!firstTouch && keepTouching)
                    {
                        //Debug.Log("Touch ended");
                        keepTouching = false;
                        endTouching = true;
                        CastARay(touch);
                    }
                }
                else if (touch.phase == TouchPhase.Stationary)
                {

                }
                else if (touch.phase == TouchPhase.Canceled)
                {

                    /*//Debug.Log("Touch canceled");
                    firstTouch = false;
                    keepTouching = false;
                    endTouching = false;
                    //RayCast(Input.GetTouch(i));     */
                    if (!firstTouch && keepTouching)
                    {
                        Debug.Log("Touch Canceled");
                        keepTouching = false;
                        endTouching = true;
                        CastARay(touch);
                    }
                }
            }           
        }
    }

    private void CastARay (Touch touch)
    {

        Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
        Vector2 direction = test - previousTouch;
        previousTouch = test;        

        // Wrong direction TO FIX 
        // to test direction or touch.position
        RaycastHit2D hit = Physics2D.Raycast(test, direction);

        if (hit.collider)
        {
            GameObject gameObject = hit.transform.gameObject;
            if (gameObject != null)
            {
                Debug.Log("hit in:" + touch.phase);
                //Destroy(gameObject);
                Puzzle puzzle = gameObject.GetComponent<Puzzle>();
                if (puzzle != null)
                    WorkWithPuzzle(puzzle);
                else
                    Debug.Log("No puzzle in gameobject :c");

            }
            else
            {
                Debug.Log("Null hit in" + touch.position);
            }
        }
        else
        {
            Debug.Log("No hit in" + touch.position);
        }
    }

    private void WorkWithPuzzle(Puzzle puzzle)
    {
        Debug.Log("We have an puzzle");

        if (firstTouch)
        {
            puzzle.OnClick();
            Debug.Log("Puzzle OnClick");
        }            
        else if (keepTouching)
        {
            puzzle.OnOver();
            Debug.Log("Puzzle OnOver");
        }
           
        else if (endTouching)
        {
            puzzleManager.Instance.FingerUp();
            Debug.Log("Grid FingerUp");
        }           
    }
}
