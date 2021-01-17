using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour {
    public GameObject textBox;
    public static int resultTime;

    // Use this for initialization
    void Start() {
        //Lanking.Reset();
        //resultTime = 145 * 60;
    }

    // Update is called once per frame
    void Update() {

    }

    public void enter() {
        if (!Title.debug) {
            if (textBox.GetComponent<InputField>().text != "") {
                switch (textBox.GetComponent<InputField>().text) {
                    case @"\seisaku":
                        Lanking.getInstance().add(new Data("<color=red>制作者</color>", resultTime));
                        break;
                    
                    case @"\bucho":
                        Lanking.getInstance().add(new Data("<color=red>部長</color>", resultTime));
                        break;
                    case @"\buin":
                        Lanking.getInstance().add(new Data("<color=red>部員</color>", resultTime));
                        break;
                    
                    default:
                        Lanking.getInstance().add(new Data(textBox.GetComponent<InputField>().text, resultTime));
                        break;
                }
            } else {
                //Lanking.getInstance().add(new Data("星野さん", resultTime));
            }
        }
        Lanking.getInstance().SaveLank(Lanking.getInstance().mode);
        if(Ending.doEnd) {
            SceneManager.LoadScene("main");
        } else {
            SceneManager.LoadScene("Title");
        }
    }
}
