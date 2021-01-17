using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {
	public enum Mode
	{
		start,
		main,
		pause,
		goal,
		gameover,
		end
	};
	public static Mode mode {
		get { 
			return _mode; 
		}
		set {
			switch (value)
			{
				case Mode.gameover:
					message.GetComponent<Text>().text = "GAME OVER";
					GameObject.Find("Main Camera").transform.parent = null;
					denaosu.SetActive(true);
                    goTitle.SetActive(true);
					//pause.GetComponent<Pausable>().pausing = true;
					//Time.timeScale = 0;
					break;
				case Mode.goal:
					pause.GetComponent<Pausable>().pausing = true;
					message.GetComponent<Text>().text = "GOAL!\nTIME:" + ((int)(time / 60 / 60)).ToString("D2") + ":" + (((int)(time / 60)) % 60).ToString("D2");
					clear.SetActive(true);
					break;
				case Mode.pause:
					message.GetComponent<Text>().text = "PAUSE";
					pause.GetComponent<Pausable>().pausing = true;
					tsuzukeru.SetActive(true);
					denaosu.SetActive(true);
                    goTitle.SetActive(true);
					break;
				case Mode.end:
					if (time > 0)
					{
						SceneManager.LoadScene("Title");
					}
					break;
			}
			_mode = value;
		}
	}
	static Mode _mode;
	public static int time;
	static public GameObject message;
	static public GameObject timer;
	static public GameObject pause;
	static public GameObject tsuzukeru;
	static public GameObject denaosu;
    static public GameObject goTitle;
    static public GameObject clear;
	static public GameObject person;

	// Use this for initialization
	void Start () {
		message = GameObject.Find("mes");
		timer = GameObject.Find("time");
		pause = GameObject.Find("pausableObjects");
		tsuzukeru = transform.Find("tsuzukeru").gameObject;
		denaosu = transform.Find("denaosu").gameObject;
		goTitle = transform.Find("goTitle").gameObject;
        clear = transform.Find("modoru").gameObject;
		person = GameObject.Find("Hoshino");

		time = 0;
		mode = Mode.start;
		pause.GetComponent<Pausable>().pausing = true;
	}
	
	// Update is called once per frame
	void Update () {
		//message.GetComponent<Text>().text = mode.ToString();
		switch (mode) {
			case Mode.start:
				if (time<60) {
					message.GetComponent<Text>().text = "3";
				}else if(time<120) {
					message.GetComponent<Text>().text = "2";
				}else if(time<180){
					message.GetComponent<Text>().text = "1";
				}else {
					message.GetComponent<Text>().text = "";
					pause.GetComponent<Pausable>().pausing = false;
					time = 0;
					mode = Mode.main;
				}
				break;
			case Mode.main:
				timer.GetComponent<Text>().text = ((int)(time / 60 / 60)).ToString("D2") + ":" + (((int)(time / 60)) % 60).ToString("D2");
				//title.GetComponent<Text>().text = Lanking.mode;
				break;
			case Mode.gameover:
				/*message.GetComponent<Text>().text = "GAME OVER";
				GameObject.Find("Main Camera").transform.parent = null;
				denaosu.SetActive(true);*/
				//pause.GetComponent<Pausable>().pausing = true;
				//Time.timeScale = 0;
				break;
			case Mode.goal:
				/*pause.GetComponent<Pausable>().pausing = true;
				message.GetComponent<Text>().text = "GOAL!\nTIME:"+ ((int)(time / 60 / 60)).ToString("D2") + ":" + (((int)(time / 60)) % 60).ToString("D2");
				clear.SetActive(true);*/
				break;
			case Mode.pause:
				/*message.GetComponent<Text>().text = "PAUSE";
				pause.GetComponent<Pausable>().pausing = true;
				tsuzukeru.SetActive(true);
				denaosu.SetActive(true);
				goTitle.SetActive(true);*/
                if (Input.GetButtonDown("Pause")) {
					unPause();
				}
				break;
			case Mode.end:
				if (time > 0)
				{
					SceneManager.LoadScene("Title");
				}
				break;
		}
        if (mode != Mode.goal) {
            if (Input.GetButtonDown("reset")) {
                Reset();
            }
            if (Input.GetKeyDown(KeyCode.Q)) {
                modoru();
            }
        }

	}

	void FixedUpdate() {
		
		if (mode == Mode.start || mode == Mode.main || mode == Mode.end) 
		{
		if(time<0) {
				time = 0;
		}
			time++;
		}else {
			
		}
	}

	public void unPause() {
		mode = Mode.main;
		message.GetComponent<Text>().text = "";
		tsuzukeru.SetActive(false);
		denaosu.SetActive(false);
		goTitle.SetActive(false);
        person.GetComponent<Person>().pause = false;
		pause.GetComponent<Pausable>().pausing = false;
	}

	public void modoru()
	{
		/*unPause();

		mode = Mode.end;
		time = 0;*/
		SceneManager.LoadScene("Title");
	}

	public void clearModoru() {
        Debug.Log("CSN:" + Lanking.getInstance().clearStageNumber);

        if (Lanking.getInstance().playingStageNumber == 2 && Lanking.getInstance().clearStageNumber == 2) {
            Ending.cleared = true;
            Ending.ura = false;
            Ending.doEnd = true;
        } else if (Lanking.getInstance().playingStageNumber == 5 && Lanking.getInstance().clearStageNumber == 5) {
            Ending.cleared = true;
            Ending.ura = true;
            Ending.doEnd = true;
        }

        if (Lanking.getInstance().lankList[4].time < time) {
            if (!Ending.doEnd) {
                modoru();
            }else {
                SceneManager.LoadScene("main");
            }
        } else {
            Entry.resultTime = time;
            SceneManager.LoadScene("NameEntry");
        }
		Lanking.getInstance().updateClearStageNumber();
	}

    public void Reset() {
        //unPause();
        SceneManager.LoadScene(Lanking.getInstance().mode);
    }
}
