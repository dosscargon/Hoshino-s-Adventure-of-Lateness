using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class select : MonoBehaviour {
	const int maxNumber = 2;
	// Use this for initialization
	void Start () {
		//new Lanking();
		/*for(int i=maxNumber;i>=0;i--) {
			GameObject.Find("Button" + i.ToString()).GetComponent<Button>().interactable = Lanking.getInstance().clearStageNumber >= i;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void A(){
		Lanking.getInstance().mode = "A";
		Lanking.getInstance().LoadLank(Lanking.getInstance().mode);
		SceneManager.LoadScene("A");
	}

	public void B()
	{
		Lanking.getInstance().mode = "B";
		Lanking.getInstance().LoadLank(Lanking.getInstance().mode);
		SceneManager.LoadScene("B");
	}

	public void C()
	{
		Lanking.getInstance().mode = "C";
		Lanking.getInstance().LoadLank(Lanking.getInstance().mode);
		SceneManager.LoadScene("C");
	}

    public void Load(string scene) {
        Lanking.getInstance().mode = scene;
        Lanking.getInstance().LoadLank(Lanking.getInstance().mode);
        SceneManager.LoadScene(scene);
    }
}
