using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseEnterMessage : MonoBehaviour {
	public GameObject textBox;
	[Multiline] public string text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter() {
        if (GetComponent<Button>().interactable) {
            textBox.GetComponent<Text>().text = text;
        }
	}
}
