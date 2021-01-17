using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OmoteButtonClicked() {
        Ending.ura = false;
        SceneManager.LoadScene("main");
    }

    public void UraButtonClicked() {
        Ending.ura = true;
        SceneManager.LoadScene("main");
    }
}
