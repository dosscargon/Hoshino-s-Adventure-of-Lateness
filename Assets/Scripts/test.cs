using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {
	public GameObject player;	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetComponent<Person>().grounded) {
			GetComponent<Text>().text = "true";
		}else {
			GetComponent<Text>().text = "false";
		}
	}


}
