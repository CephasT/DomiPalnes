using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test_1 : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        Debug.Log("Hi");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TogglePanel(int Panel_Number) {
        GameCore.GetSystem<UIManager>().TogglePanel("Panel"+Panel_Number);        
    }

    public void NextScene() {
        SceneManager.LoadScene("SecondScene");
    }
}
