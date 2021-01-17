using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour {
    public static bool debug = false;
    bool doInput;

    public Text debugMessage;

	// Use this for initialization
	void Start () {
        doInput = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q) && Input.GetKeyDown(KeyCode.D)) {
            doInput = !doInput;
            Debug.Log("doinput:" + doInput);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.UpArrow) && doInput){
            debug = !debug;
            debugMessage.text = "DEBUG:" + debug;
        }

        if (Input.GetKey(KeyCode.K) && debug){
            if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                Lanking.getInstance().clearStageNumber--;
                Debug.Log("CSM changed:" + Lanking.getInstance().clearStageNumber);
                debugMessage.text = "open:" + Lanking.getInstance().clearStageNumber;
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)) {
                Lanking.getInstance().clearStageNumber++;
                Debug.Log("CSM changed:" + Lanking.getInstance().clearStageNumber);
                debugMessage.text = "open:" + Lanking.getInstance().clearStageNumber;
            }

            
        }
	}

	public  void GameStart() {
		SceneManager.LoadScene("A");
	}

	public void Load(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

    public void Exit() {
        Application.Quit();
    }

}
