using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnButtonClick : MonoBehaviour {
 
    public GameObject yourButton;

	void Start () {
		//Button btn = this.yourButton.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);
		Debug.Log(this.yourButton.name);
	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
	}
	private void OnMouseDown() {
		Debug.Log(this.yourButton.name);
	}
}