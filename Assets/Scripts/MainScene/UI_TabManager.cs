using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TabManager : MonoBehaviour
{
    [SerializeField] Button _exitBtn;
    UI_Manager_MainScene _ui_Manager;
    Vector3 _hidePosition;
    Vector3 _showPosition;

    float _startTime;
    float _journeyLength;
    [SerializeField] float speed = 1f;

    RectTransform rectTransform;

    public UI_Manager_MainScene.UI_Element _tabType = new UI_Manager_MainScene.UI_Element();

    // Start is called before the first frame update
    void Start()
    {
        _showPosition = Vector3.zero;
        _hidePosition = new Vector3(0,-900,0);      
        _journeyLength = Vector3.Distance(_hidePosition, _showPosition);

        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = _hidePosition;

        _ui_Manager = transform.parent.GetComponent<UI_Manager_MainScene>();
        _exitBtn.onClick.AddListener(CloseUpWindow);
    }

    // Update is called once per frame
    void Update()
    {
        if (rectTransform.localPosition != _showPosition)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - _startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / _journeyLength;

            Vector3 positionToLerp = Vector3.Lerp(rectTransform.localPosition, _showPosition, fractionOfJourney);

            // Set our position as a fraction of the distance between the markers.
            // After awake positionToLerp is Nan
            rectTransform.localPosition = positionToLerp;
        }
    }
    void OnDisable()
    {
        rectTransform.localPosition = _hidePosition;
        //Debug.Log("PrintOnDisable: script was disabled");
    }

    void OnEnable()
    {
        //Debug.Log("PrintOnEnable: script was enabled");
        _startTime = Time.time;
    }

    void CloseUpWindow()
    {
        //Debug.Log("CloseUp Window");
        _ui_Manager.CloseUpWindow(_tabType);
    }
}

