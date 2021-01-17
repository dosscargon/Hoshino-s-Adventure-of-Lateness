using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {
	static bool flag=false;
	// Use this for initialization
	void Start () {
		if (!flag)
		{
			Lanking.getInstance();
			flag = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
