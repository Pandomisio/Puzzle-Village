using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Button button; 
    // Start is called before the first frame update
    void Start()
    {
        button=GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        SceneManager.LoadScene(button.name);
    }
}
