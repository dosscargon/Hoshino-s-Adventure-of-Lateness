using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LankScr : MonoBehaviour {
	int mode = 0;
	public GameObject tex;
	public GameObject[] userName = new GameObject[5];
	public GameObject[] record = new GameObject[5];


	// Use this for initialization
	void Start () {
		mode = -1;
		changeMode(1);
		Show();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setRecord() {
		switch(mode) {
			case 0:
				break;
			case 1:
				break;
			case 2:
				break;
		}
	}

	public void changeMode(int i) {
		mode += i;
        mode += Lanking.getInstance().clearStageNumber == 0 ? 1 : Lanking.getInstance().clearStageNumber;
		mode %= Lanking.getInstance().clearStageNumber == 0 ? 1 : Lanking.getInstance().clearStageNumber;
        switch (mode) {
			case 0:
				Lanking.getInstance().LoadLank("A");
				tex.GetComponent<Text>().text = "やさしい";
				break;
			case 1:
				Lanking.getInstance().LoadLank("B");
				tex.GetComponent<Text>().text = "ふつう";
				break;
			case 2:
				Lanking.getInstance().LoadLank("C");
				tex.GetComponent<Text>().text = "たいへん";
				break;
            case 3:
                Lanking.getInstance().LoadLank("EX_A");
                tex.GetComponent<Text>().text = "やさしくない";
                break;
            case 4:
                Lanking.getInstance().LoadLank("EX_B");
                tex.GetComponent<Text>().text = "ふつうじゃない";
                break;
            case 5:
                Lanking.getInstance().LoadLank("EX_C");
                tex.GetComponent<Text>().text = "すごくたいへん";
                break;
        }
		Show();
	}

	public void Show() {
		for(int i=0;i<5;i++) {
			userName[i].GetComponent<Text>().text = Lanking.getInstance().lankList[i].name;
			record[i].GetComponent<Text>().text = ((int)(Lanking.getInstance().lankList[i].time / 60 / 60)).ToString("D2") + ":" + (((int)(Lanking.getInstance().lankList[i].time / 60)) % 60).ToString("D2"); ;
		}
	}
}
