using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {
	private string _name="";
	private bool _speaking=true;
	
	//Imageの色を更新
	private void SetupColor() {
		if (_name!=""){
			if(speaking) {
				GetComponent<Image>().color = Color.white;
			}else {
				GetComponent<Image>().color = Color.gray;
			}
		}else {
			GetComponent<Image>().color = Color.clear;
		}
	}

	/// <summary>
	/// キャラクターの名前を設定します。代入された名前に応じて自動的に画像が設定されます。
	/// </summary>
	public string characterName
	{
		get {
			return _name; 
		}

		set {
			_name = value;
			if (value != ""){
				Texture2D tex = (Texture2D)Resources.Load(_name);
				GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
				GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, 650), Vector2.zero);

			    GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<Image>().sprite.bounds.size.x * 100f, GetComponent<Image>().sprite.bounds.size.y * 100f);
				SetupColor();
			}else {
				
				SetupColor();
			}
		}
	}

	/// <summary>
	/// falseに設定するとキャラクターの画像が暗くなります。
	/// </summary>
	public bool speaking {
		get {
			return _speaking;
		}
		set {
			_speaking = value;
			SetupColor();
		}
	}



	// Use this for initialization
	void Start () {
		//speaking = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
