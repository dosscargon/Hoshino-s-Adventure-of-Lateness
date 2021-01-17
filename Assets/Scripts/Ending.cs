using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {
    static public bool cleared=false;

    public GameObject rollObject;
    public GameObject stopObject;

    public float speed;
    public float pow;

    public float stopPos;

    public float startWaitTime;
    public float endWaitTime;

    public static bool ura = false;
    public static bool doEnd = false;

    public GameObject debugText;

    float defaultPos;

    bool doRoll = false;

    // Use this for initialization
    void Start () {
        StartCoroutine("roll");
        doEnd = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Q)) {
            SceneManager.LoadScene("Title");
        }
	}

    void FixedUpdate() {
        //Debug.Log(stopObject.GetComponent<RectTransform>().position+" : "+((stopPos - defaultPos) / speed) / 60.0f);
        //debugText.GetComponent<Text>().text = stopObject.GetComponent<RectTransform>().position.y.ToString();

        if(stopObject.GetComponent<RectTransform>().position.y <= stopPos && doRoll) {
            rollObject.GetComponent<RectTransform>().position += new Vector3(0, ((stopPos - defaultPos) / speed) / 60.0f, 0);
        }
    }

    IEnumerator roll() {
        defaultPos = stopObject.GetComponent<RectTransform>().position.y;
        yield return new WaitForSeconds(startWaitTime);

        doRoll = true;

        while (stopObject.GetComponent<RectTransform>().position.y <= stopPos) {
            yield return null;
        }


        yield return new WaitForSeconds(endWaitTime);

        SceneManager.LoadScene("Title");

        //start
    }
}
