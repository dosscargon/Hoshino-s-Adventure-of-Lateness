﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0.1f, 0, 0);
	}
}
