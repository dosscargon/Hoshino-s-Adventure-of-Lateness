using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
	ScriptReader reader;
	private Character[] characters = new Character[3];
	private Message message;
	private Text speaker;
    private Image backGround;
    private Image backGround2;

    private bool exiting = false;
    public GameObject screen;


	// Use this for initialization
	void Start () {
		//ApplicationChrome.statusBarState = ApplicationChrome.States.Visible;
		characters[0] = GameObject.Find("left").GetComponent<Character>();
		characters[1] = GameObject.Find("center").GetComponent<Character>();
		characters[2] = GameObject.Find("right").GetComponent<Character>();

		message = GameObject.Find("message").GetComponent<Message>();
		speaker = GameObject.Find("speaker").GetComponent<Text>();
        backGround = GameObject.Find("bg").GetComponent<Image>();
        backGround2 = GameObject.Find("bg2").GetComponent<Image>();

        reader = new ScriptReader();

        Click();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Click();
		}
		if(Input.GetKeyDown(KeyCode.Q)) {
            if (!Ending.ura) {
                SceneManager.LoadScene("ending");
            } else {
                SceneManager.LoadScene("endingUra");
            }
        }
	}

	/// <summary>
	/// 画面をクリックされたときに呼び出されるメソッドです。
	/// </summary>
	public void Click() {
		//Debug.Log(reader.command);
		if (message.completed) {
            while (true && !exiting) {
                //ループ用（仮）
                if(!reader.ReadScript()) {
					reader = new ScriptReader();
				}

                if (reader.command == "speak" && !exiting) {
                    //メッセージ表示
                    if (reader.arguments.Count >= 1) {
                        if (reader.arguments.Count >= 2) {
                            speaker.text = reader.arguments[1];
                        }
                        message.SetMessage(reader.arguments[0]);
                    }

                    break;

                } else if (reader.command == "setCharacter") {
                    //キャラクターセット

                    try {
                        characters[int.Parse(reader.arguments[1])].characterName = reader.arguments[0];
                    } catch (System.Exception) { }


                } else if (reader.command == "setSpeaker") {
                    //キャラクターの色変更
                    if (reader.arguments.Count >= 1) {
                        int arg;

                        int.TryParse(reader.arguments[0], out arg);
                        for (int i = 0; i < characters.Length; i++) {
                            if (i == arg) {
                                characters[i].speaking = true;
                            } else {
                                characters[i].speaking = false;
                            }
                        }
                    }
                } else if (reader.command == "changeBackGround") {
                    //背景変更
                    if(reader.arguments[0]=="ura") {
                        backGround2.enabled = true;
                    }else {
                        backGround2.enabled = false;
                    }

                } else if (reader.command == "exit") {
                    if (!exiting) {
                        StartCoroutine("Fadeout");
                        exiting = true;
                    }
                }
			}
		}else {
			GameObject.Find("message").GetComponent<Message>().Skip();
		}
	}

    IEnumerator Fadeout() {
        while (screen.GetComponent<Image>().color.a <= 1) {
            screen.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            Debug.Log(screen.GetComponent<Image>().color);
            yield return null;
        }

        if(!Ending.ura) {
            SceneManager.LoadScene("ending");
        }else {
            SceneManager.LoadScene("endingUra");
        }
    }
}