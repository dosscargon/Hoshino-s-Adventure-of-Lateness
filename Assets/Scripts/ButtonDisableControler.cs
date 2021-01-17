using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisableControler : MonoBehaviour {
    public int needStageNumber;

	// Use this for initialization
	void Start () {
        GetComponent<Button>().interactable = Lanking.getInstance().clearStageNumber >= needStageNumber;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
