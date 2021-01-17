using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {
	private const int wait = 1;
	private int timer = 0;
	private string text="";//最終的に表示させるテキスト
	private int index;//今何文字目？
	private bool colorMode = false;//<color>の中にいるか
	private string tmp="";//現在表示中のテキスト。ただし後ろに<color>がつかない

	/// <summary>
	/// テキストを最後まで表示したかを返します。
	/// </summary>
	public bool completed {
		get {
			if(index==text.Length) {
				return true;
			}else {
				return false;
			}
		}
	}

	/// <summary>
	/// 表示するメッセージを設定します。設定されたメッセージは、一定の間隔で一文字ずつ追加されます。
	/// </summary>
	/// <param name="text">表示するメッセージ</param>
	public void SetMessage(string text) {
		this.text = text;
		index = 0;
		GetComponent<Text>().text = "";
		tmp = "";
		colorMode = false;
	}

	/// <summary>
	/// メッセージを最後まで表示します。
	/// </summary>
	public void Skip() {
		GetComponent<Text>().text = text;
		index = text.Length;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(timer==wait) { 
			if (index < text.Length) {
				if(text[index]=='<') {
					do {
						tmp += text[index].ToString();
						index++;
					} while (text[index - 1] != '>');
					colorMode = !colorMode;
				}

				tmp = tmp + text[index].ToString();
				if(!colorMode) {
					GetComponent<Text>().text = tmp;
				}else {
					GetComponent<Text>().text = tmp + "</color>";
				}
				index++;
			}
		}

		timer = wait != 0 ? (timer + 1) % (wait + 1) : wait;
	}
}
